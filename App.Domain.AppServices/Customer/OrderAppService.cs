using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Customer.Contracts.AppServices;
using App.Domain.Core.Customer.Contracts.Services;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Customer.Enums;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Permission.Contracts.Services;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace App.Domain.AppServices.Customer
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IExpertServiceService _expertServiceService;
        private readonly ITenderService _tenderService;
        private readonly IPastWorkService _pastWorkService;
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderAppService> _logger;
        private readonly IDistributedCache _cache;

        public OrderAppService(IOrderService orderService,
            IUserService userService,
            IExpertServiceService expertServiceService,
            ITenderService tenderService,
            IPastWorkService pastWorkService,
            IPermissionService permissionService,
            IMapper mapper,
            ILogger<OrderAppService> logger,
            IDistributedCache cache)
        {
            _orderService = orderService;
            _userService = userService;
            _expertServiceService = expertServiceService;
            _tenderService = tenderService;
            _pastWorkService = pastWorkService;
            _permissionService = permissionService;
            _mapper = mapper;
            _logger = logger;
            _cache = cache;
        }
        public async Task<int> Add(OrderDto dto, CancellationToken cancellationToken)
        {
            dto.RegisterDate = DateTime.Now;
            if (dto.OrderStateId == 0)
                dto.OrderStateId = (int)OrderStateEnum.WaitingForTender;
            dto.CustomerId = await _userService.ConvertUserIdToCustomerId(dto.CustomerId, cancellationToken);
            int id = await _orderService.Add(dto, cancellationToken);
            return id;
        }

        public async Task<int> Delete(int id, int customerId, CancellationToken cancellationToken)
        {
            customerId = await _userService.ConvertUserIdToCustomerId(customerId, cancellationToken);
            if (await _permissionService.HasPermissionDeleteOrder(customerId, id, cancellationToken))
            {
                int entityId = await _orderService.Delete(id, cancellationToken);
                return entityId;
            }
            _logger.LogError("Customer with id: {customerId} tried to run method {method} on order with id: {orderId} and denied", customerId, nameof(Delete), id);
            throw new Exception("You have not permission to delete another one customer order");
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            int entityId = await _orderService.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<int> Done(int tenderId, CancellationToken cancellationToken)
        {
            int orderId = (await _tenderService.Get(tenderId, cancellationToken)).OrderId;
            int id = await _pastWorkService.Add(tenderId, DateTime.Now, cancellationToken);
            var tenders = await _tenderService.GetByOrder(orderId, cancellationToken);
            await _orderService.Delete(orderId, cancellationToken);
            foreach (var tender in tenders)
                await _tenderService.Delete(tender.Id, cancellationToken);
            return id;
        }

        public async Task<OrderDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _orderService.Get(id, cancellationToken);
            return dto;
        }

        public async Task<OrderDto?> Get(int id, int customerId, CancellationToken cancellationToken)
        {
            customerId = await _userService.ConvertUserIdToCustomerId(customerId, cancellationToken);
            var dto = await _orderService.Get(id, cancellationToken);
            if (dto == null)
            {
                _logger.LogError("customer by id={id} tried to see order by id={orderId} but this order dose'nt exists", customerId, id);
                throw new Exception($"Order with id = \"{id}\" not found!");
            }
            if (dto.CustomerId != customerId)
            {
                _logger.LogError("customer by id={id} tried to see order {order} but not permitted", customerId, dto);
                throw new Exception("you have not permission to view this order");
            }
            return dto;
        }

        public async Task<List<OrderDto>> GetAll(string keyWord, CancellationToken cancellationToken)
        {
            var dtos = await GetAll(cancellationToken);
            if (keyWord == null)
            {
                return dtos;
            }
            keyWord = keyWord.ToLower();
            var filterDtos = dtos.Where(d => d.Customer.ToLower().Contains(keyWord) || d.Service.ToLower().Contains(keyWord) || d.OrderState.ToLower().Contains(keyWord)).ToList();
            return filterDtos;
        }

        public async Task<List<OrderDto>> GetAll(CancellationToken cancellationToken)
        {
            var bytesOfCachedValue = _cache.Get("AllOrders");
            List<OrderDto> services;
            if (bytesOfCachedValue != null)
            {
                services = JsonConvert.DeserializeObject<List<OrderDto>>(Encoding.UTF8.GetString(bytesOfCachedValue));
                _logger.LogInformation("List of orders has read from cache");
            }
            else
            {
                services = await _orderService.GetAll(cancellationToken);
                _logger.LogInformation("List of orders has read from database");
                var serializedValue = JsonConvert.SerializeObject(services);
                var bytesOfValue = Encoding.UTF8.GetBytes(serializedValue);
                _cache.Set("AllOrders", bytesOfValue, new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1),
                });
            }
            if (services.Count == 0)
                _logger.LogWarning("something is wrong. result of {Service} is empty", "OrderService");
            return services;
        }

        public async Task<List<OrderDto>> GetByCustomerId(int id, string keyWord, CancellationToken cancellationToken)
        {
            var customerId = await _userService.ConvertUserIdToCustomerId(id, cancellationToken);
            var dtos = await _orderService.GetAll(cancellationToken);
            var customersDtos = dtos.Where(o => o.CustomerId == customerId).ToList();
            if (keyWord == null)
            {
                //_logger.LogTrace("finish method {methodName} without any search keyWord", nameof(GetAll));
                return customersDtos;
            }
            //_logger.LogDebug("a search on keyWord : {keyWord} is performed", keyWord);
            keyWord = keyWord.ToLower();
            var filterDtos = customersDtos.Where(o => o.Service.ToLower().Contains(keyWord)).ToList();
            //_logger.LogTrace("finish method {methodName} with a search keyWord", nameof(GetAll));
            return filterDtos;
        }

        public async Task<List<OrderForExpertDto>> GetByExpertId(int id, CancellationToken cancellationToken)
        {
            var expertId = await _userService.ConvertUserIdToExpertId(id, cancellationToken);
            var expertServices = await _expertServiceService.GetByExpertId(expertId, cancellationToken);
            var orders = new List<OrderDto>();
            foreach (var expertService in expertServices)
                orders.AddRange(await _orderService.GetByServiceId(expertService.ServiceId, cancellationToken));
            orders = orders.Where(order => order.OrderStateId == (int)OrderStateEnum.WaitingForTender || order.OrderStateId == (int)OrderStateEnum.WaitingForChoseExpert
            || order.OrderStateId == (int)OrderStateEnum.WaitingForArriveExpert).ToList();
            var orderForExperts = _mapper.Map<List<OrderForExpertDto>>(orders);
            var tenders = await _tenderService.GetByExpertId(expertId, cancellationToken);
            foreach (var tender in tenders)
            {
                orderForExperts.First(o => o.Id == tender.OrderId).TenderId = tender.Id;
            }
            orderForExperts = orderForExperts.Where(o => o.OrderStateId != (int)OrderStateEnum.WaitingForArriveExpert ||
            (tenders.FirstOrDefault(t => t.Id == o.TenderId) != null && tenders.FirstOrDefault(t => t.Id == o.TenderId).Accepted)).ToList();
            return orderForExperts;
        }

        public async Task<int> Update(OrderDto dto, CancellationToken cancellationToken)
        {
            int id = await _orderService.Update(dto, cancellationToken);
            return id;
        }
    }
}

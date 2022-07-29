using App.Domain.Core.Customer.Contracts.AppServices;
using App.Domain.Core.Customer.Contracts.Services;
using App.Domain.Core.Customer.Dtos;

namespace App.Domain.AppServices.Customer
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderService _orderService;

        public OrderAppService(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<int> Add(OrderDto dto)
        {
            dto.RegisterDate = DateTime.Now;
            int id = await _orderService.Add(dto);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int entityId = await _orderService.Delete(id);
            return entityId;
        }

        public async Task<OrderDto?> Get(int id)
        {
            var dto = await _orderService.Get(id);
            return dto;
        }

        public async Task<List<OrderDto>> GetAll(string keyWord)
        {
            var dtos = await _orderService.GetAll();
            if (keyWord == null)
            {
                return dtos;
            }
            keyWord = keyWord.ToLower();
            var filterDtos = dtos.Where(d => d.Customer.Contains(keyWord) || d.Service.Contains(keyWord) || d.OrderState.Contains(keyWord)).ToList();
            return filterDtos;
        }

        public async Task<int> Update(OrderDto dto)
        {
            int id = await _orderService.Update(dto);
            return id;
        }
    }
}

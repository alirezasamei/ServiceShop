using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Customer.Contracts.Services;
using App.Domain.Core.Customer.Enums;
using App.Domain.Core.Expert.Contracts.AppServices;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Services.Expert
{
    public class TenderAppService : ITenderAppService
    {
        private readonly ITenderService _tenderService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public TenderAppService(ITenderService tenderService,
            IUserService userService,
            IOrderService orderService)
        {
            _tenderService = tenderService;
            _userService = userService;
            _orderService = orderService;
        }
        public async Task<int> Add(TenderDto dto, CancellationToken cancellationToken)
        {
            dto.ExpertId = await _userService.ConvertUserIdToExpertId(dto.ExpertId, cancellationToken);
            dto.RegisterDate = DateTime.Now;
            int id = await _tenderService.Add(dto, cancellationToken);
            int tenderCount = (await _tenderService.GetByOrder(dto.OrderId, cancellationToken)).Count;
            if (tenderCount == 1)
            {
                await _orderService.UpdateState(dto.OrderId, (int)OrderStateEnum.WaitingForChoseExpert, cancellationToken);
            }
            return id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var dto = await _tenderService.Get(id, cancellationToken);
            int entityId = await _tenderService.Delete(id, cancellationToken);
            int tenderCount = (await _tenderService.GetByOrder(dto.OrderId, cancellationToken)).Count;
            if (tenderCount == 0)
            {
                await _orderService.UpdateState(dto.OrderId, (int)OrderStateEnum.WaitingForTender, cancellationToken);
            }
            return entityId;
        }

        public async Task<TenderDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _tenderService.Get(id, cancellationToken);
            return dto;
        }

        public async Task<List<TenderDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _tenderService.GetAll(cancellationToken);
            return dtos;
        }

        public async Task<List<TenderDto>?> GetByOrder(int orderId, CancellationToken cancellationToken)
        {
            var dtos = await _tenderService.GetByOrder(orderId, cancellationToken);
            return dtos;
        }

        public async Task<List<TenderAndOrderDto>?> GetTendersAndOrdersByExpertId(int id, CancellationToken cancellationToken)
        {
            var expertId = await _userService.ConvertUserIdToExpertId(id, cancellationToken);
            var dtos = new List<TenderAndOrderDto>();
            var tenders = await _tenderService.GetByExpertId(expertId, cancellationToken);
            var orders = await _orderService.GetAll(cancellationToken);
            dtos = tenders.Select(t => new TenderAndOrderDto
            {
                Tender = t,
                Order = orders.First(o => o.Id == t.OrderId)
            }).Where(to => to.Order.OrderStateId != (int)OrderStateEnum.WaitingForArriveExpert || to.Tender.Accepted).ToList();
            return dtos;
        }

        public async Task<int> Update(TenderDto dto, CancellationToken cancellationToken)
        {
            int id = await _tenderService.Update(dto, cancellationToken);
            return id;
        }

        public async Task<TenderDto> Accept(int id, CancellationToken cancellationToken)
        {
            var tender = await _tenderService.Accept(id, cancellationToken);
            var order = await _orderService.Get(tender.OrderId, cancellationToken);
            if (order.OrderStateId == (int)OrderStateEnum.WaitingForChoseExpert)
                await _orderService.UpdateState(tender.OrderId, (int)OrderStateEnum.WaitingForArriveExpert, cancellationToken);
            else
                throw new Exception("another tender is accepted for this order");
            return tender;
        }

        public async Task<TenderDto> Cancel(int id, CancellationToken cancellationToken)
        {
            var dto = await _tenderService.Cancel(id, cancellationToken);
            await _orderService.UpdateState(dto.OrderId, (int)OrderStateEnum.WaitingForChoseExpert, cancellationToken);
            return dto;
        }
    }
}

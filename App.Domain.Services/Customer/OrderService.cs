using App.Domain.Core.Customer.Contracts.Repositories;
using App.Domain.Core.Customer.Contracts.Services;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Customer.Enums;

namespace App.Domain.Services.Customer
{
    public class OrderService : IOrderService
    {
        private readonly IOrderQueryRepository _orderQueryRepository;
        private readonly IOrderCommandRepository _orderCommandRepository;

        public OrderService(IOrderQueryRepository orderQueryRepository,
            IOrderCommandRepository orderCommandRepository)
        {
            _orderQueryRepository = orderQueryRepository;
            _orderCommandRepository = orderCommandRepository;
        }
        public async Task<int> Add(OrderDto dto, CancellationToken cancellationToken)
        {
            int id = await _orderCommandRepository.Add(dto, cancellationToken);
            return id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            int entityId = await _orderCommandRepository.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<OrderDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _orderQueryRepository.Get(id, cancellationToken);
            return dto;
        }

        public async Task<List<OrderDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _orderQueryRepository.GetAll(cancellationToken);
            return dtos;
        }

        public async Task<List<OrderDto>> GetByServiceId(int serviceId, CancellationToken cancellationToken)
        {
            var dtos = await _orderQueryRepository.GetByServiceId(serviceId, cancellationToken);
            return dtos;
        }

        public async Task<int> Update(OrderDto dto, CancellationToken cancellationToken)
        {
            int id = await _orderCommandRepository.Update(dto, cancellationToken);
            return id;
        }

        public async Task<int> UpdateState(int orderId, int stateId, CancellationToken cancellationToken)
        {
            int id = await _orderCommandRepository.UpdateState(orderId, stateId, cancellationToken);
            return id;
        }
    }
}

using App.Domain.Core.Customer.Contracts.Repositories;
using App.Domain.Core.Customer.Contracts.Services;
using App.Domain.Core.Customer.Dtos;

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
        public async Task<int> Add(OrderDto dto)
        {
            int id = await _orderCommandRepository.Add(dto);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int entityId = await _orderCommandRepository.Delete(id);
            return entityId;
        }

        public async Task<OrderDto?> Get(int id)
        {
            var dto = await _orderQueryRepository.Get(id);
            return dto;
        }

        public async Task<List<OrderDto>> GetAll()
        {
            var dtos = await _orderQueryRepository.GetAll();
            return dtos;
        }

        public async Task<int> Update(OrderDto dto)
        {
            int id = await _orderCommandRepository.Update(dto);
            return id;
        }
    }
}

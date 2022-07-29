using App.Domain.Core.Customer.Contracts.Repositories;
using App.Domain.Core.Customer.Contracts.Services;
using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Services.Customer
{
    public class OrderStateService : IOrderStateService
    {
        private readonly IOrderStateQueryRepository _orderStateQueryRepository;
        private readonly IOrderStateCommandRepository _orderStateCommandRepository;

        public OrderStateService(IOrderStateQueryRepository orderStateQueryRepository,
            IOrderStateCommandRepository orderStateCommandRepository)
        {
            _orderStateQueryRepository = orderStateQueryRepository;
            _orderStateCommandRepository = orderStateCommandRepository;
        }
        public async Task<int> Add(string name)
        {
            int id = await _orderStateCommandRepository.Add(name);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int entityId = await _orderStateCommandRepository.Delete(id);
            return entityId;
        }

        public async Task<OrderStateDto?> Get(int id)
        {
            var dto = await _orderStateQueryRepository.Get(id);
            return dto;
        }

        public async Task<List<OrderStateDto>> GetAll()
        {
            var dtos = await _orderStateQueryRepository.GetAll();
            return dtos;
        }

        public async Task<int> Update(int id, string name)
        {
            int entityId = await _orderStateCommandRepository.Update(id, name);
            return entityId;
        }
    }
}

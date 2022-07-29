using App.Domain.Core.Customer.Contracts.AppServices;
using App.Domain.Core.Customer.Contracts.Services;
using App.Domain.Core.Customer.Dtos;

namespace App.Domain.AppServices.Customer
{
    public class OrderStateAppService : IOrderStateAppService
    {
        private readonly IOrderStateService _orderStateService;

        public OrderStateAppService(IOrderStateService orderStateService)
        {
            _orderStateService = orderStateService;
        }
        public async Task<int> Add(string name)
        {
            int id = await _orderStateService.Add(name);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int entityId = await _orderStateService.Delete(id);
            return entityId;
        }

        public async Task<OrderStateDto?> Get(int id)
        {
            var dto = await _orderStateService.Get(id);
            return dto;
        }

        public async Task<List<OrderStateDto>> GetAll()
        {
            var dtos = await _orderStateService.GetAll();
            return dtos;
        }

        public async Task<int> Update(int id, string name)
        {
            int entityId = await _orderStateService.Update(id, name);
            return entityId;
        }
    }
}

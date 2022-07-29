using App.Domain.Core.Expert.Contracts.AppServices;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Services.Expert
{
    public class TenderAppService : ITenderAppService
    {
        private readonly ITenderService _tenderService;

        public TenderAppService(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }
        public async Task<int> Add(TenderDto dto)
        {
            dto.RegisterDate = DateTime.Now;
            int id = await _tenderService.Add(dto);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int entityId = await _tenderService.Delete(id);
            return entityId;
        }

        public async Task<TenderDto?> Get(int id)
        {
            var dto = await _tenderService.Get(id);
            return dto;
        }

        public async Task<List<TenderDto>> GetAll()
        {
            var dtos = await _tenderService.GetAll();
            return dtos;
        }

        public async Task<List<TenderDto>?> GetByOrder(int orderId)
        {
            var dtos = (await _tenderService.GetAll()).Where(d => d.OrderId == orderId).ToList();
            return dtos;
        }

        public async Task<int> Update(TenderDto dto)
        {
            int id = await _tenderService.Update(dto);
            return id;
        }
    }
}

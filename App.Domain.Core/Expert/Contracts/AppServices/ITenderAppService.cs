using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.AppServices
{
    public interface ITenderAppService
    {
        Task<int> Add(TenderDto dto);
        Task<int> Update(TenderDto dto);
        Task<int> Delete(int id);
        Task<List<TenderDto>> GetAll();
        Task<TenderDto?> Get(int id);
        Task<List<TenderDto>?> GetByOrder(int orderId);
    }
}

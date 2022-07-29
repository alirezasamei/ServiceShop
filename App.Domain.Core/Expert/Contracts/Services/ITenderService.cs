using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Services
{
    public interface ITenderService
    {
        Task<int> Add(TenderDto dto);
        Task<int> Update(TenderDto dto);
        Task<int> Delete(int id);
        Task<List<TenderDto>> GetAll();
        Task<TenderDto?> Get(int id);
    }
}

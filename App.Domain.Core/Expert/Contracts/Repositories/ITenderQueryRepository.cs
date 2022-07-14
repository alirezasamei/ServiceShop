using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface ITenderQueryRepository
    {
        Task<List<TenderDto>> GetAll();
        Task<TenderDto?> Get(int id);
    }
}

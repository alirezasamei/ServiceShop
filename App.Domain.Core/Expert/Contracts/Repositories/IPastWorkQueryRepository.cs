using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IPastWorkQueryRepository
    {
        Task<List<PastWorkDto>> GetAll();
        Task<PastWorkDto?> Get(int id);
    }
}

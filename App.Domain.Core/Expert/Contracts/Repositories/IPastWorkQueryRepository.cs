using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IPastWorkQueryRepository
    {
        Task<List<PastWorkDto>> GetAll(CancellationToken cancellationToken);
        Task<PastWorkDto?> Get(int id, CancellationToken cancellationToken);
        Task<List<PastWorkDto>> GetByCustomerId(int id, CancellationToken cancellationToken);
        Task<List<PastWorkDto>> GetByExpertId(int id, CancellationToken cancellationToken);
    }
}

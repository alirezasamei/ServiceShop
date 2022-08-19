using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IExpertServiceQueryRepository
    {
        Task<List<ExpertServiceDto>> GetAll(CancellationToken cancellationToken);
        Task<ExpertServiceDto?> Get(int id, CancellationToken cancellationToken);
        Task<List<ExpertServiceDto>> GetByExpertId(int id, CancellationToken cancellationToken);
    }
}

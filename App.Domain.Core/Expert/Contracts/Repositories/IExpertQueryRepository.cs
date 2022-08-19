using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IExpertQueryRepository
    {
        Task<List<ExpertDto>> GetAll(CancellationToken cancellationToken);
        Task<ExpertDto?> Get(int appUserId, CancellationToken cancellationToken);
        Task<bool> DoseExists(int appUserId, CancellationToken cancellationToken);
    }
}

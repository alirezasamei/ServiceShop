using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IExpertServiceCommandRepository
    {
        Task<int> Add(ExpertServiceDto dto, CancellationToken cancellationToken);
        Task<int> Update(ExpertServiceDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}

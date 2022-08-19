using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IExpertCommandRepository
    {
        Task<int> Add(ExpertDto dto, CancellationToken cancellationToken);
        Task<int> Update(ExpertDto dto, CancellationToken cancellationToken);
    }
}

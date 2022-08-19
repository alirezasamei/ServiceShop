using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IPastWorkCommandRepository
    {
        Task<int> Add(PastWorkDto dto, CancellationToken cancellationToken);
        Task<int> Add(int tenderId, DateTime complitionDate, CancellationToken cancellationToken);
        Task<int> Update(PastWorkDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}

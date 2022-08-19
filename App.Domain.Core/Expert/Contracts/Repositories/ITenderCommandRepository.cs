using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface ITenderCommandRepository
    {
        Task<int> Add(TenderDto dto, CancellationToken cancellationToken);
        Task<int> Update(TenderDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<TenderDto> Accept(int id, CancellationToken cancellationToken);
        Task<TenderDto> Cancel(int id, CancellationToken cancellationToken);
    }
}

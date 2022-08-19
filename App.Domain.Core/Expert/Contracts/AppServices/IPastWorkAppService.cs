using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.AppServices
{
    public interface IPastWorkAppService
    {
        Task<int> Add(PastWorkDto dto, CancellationToken cancellationToken);
        Task<int> Update(PastWorkDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<PastWorkDto>> GetAll(CancellationToken cancellationToken);
        Task<PastWorkDto?> Get(int id, CancellationToken cancellationToken);
        Task<List<PastWorkDto>> GetByCustomerId(int id, CancellationToken cancellationToken);
        Task<List<PastWorkDto>> GetByExpertId(int id, CancellationToken cancellationToken);
    }
}

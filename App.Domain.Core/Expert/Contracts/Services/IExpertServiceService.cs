using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Services
{
    public interface IExpertServiceService
    {
        Task<int> Add(ExpertServiceDto dto, CancellationToken cancellationToken);
        Task<int> Update(ExpertServiceDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<ExpertServiceDto>> GetAll(CancellationToken cancellationToken);
        Task<ExpertServiceDto?> Get(int id, CancellationToken cancellationToken);
        Task<List<ExpertServiceDto>> GetByExpertId(int id, CancellationToken cancellationToken);
    }
}

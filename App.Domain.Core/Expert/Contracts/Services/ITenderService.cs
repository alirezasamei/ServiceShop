using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Services
{
    public interface ITenderService
    {
        Task<int> Add(TenderDto dto, CancellationToken cancellationToken);
        Task<int> Update(TenderDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<TenderDto>> GetAll(CancellationToken cancellationToken);
        Task<TenderDto?> Get(int id, CancellationToken cancellationToken);
        Task<List<TenderDto>> GetByOrder(int orderId, CancellationToken cancellationToken);
        Task<TenderDto> Accept(int id, CancellationToken cancellationToken);
        Task<TenderDto> Cancel(int id, CancellationToken cancellationToken);
        Task<List<TenderDto>?> GetByExpertId(int id, CancellationToken cancellationToken);
    }
}

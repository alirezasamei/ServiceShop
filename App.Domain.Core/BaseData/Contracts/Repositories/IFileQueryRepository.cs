using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IFileQueryRepository
    {
        Task<List<FileDto>> GetAll(CancellationToken cancellationToken);
        Task<FileDto?> Get(string id, CancellationToken cancellationToken);
    }
}

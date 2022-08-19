using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IFileService
    {
        Task<Guid> Add(FileDto dto, CancellationToken cancellationToken);
        Task<Guid> Update(FileDto dto, CancellationToken cancellationToken);
        Task<Guid> Delete(string id, CancellationToken cancellationToken);
        Task<List<FileDto>> GetAll(CancellationToken cancellationToken);
        Task<FileDto?> Get(string id, CancellationToken cancellationToken);
    }
}

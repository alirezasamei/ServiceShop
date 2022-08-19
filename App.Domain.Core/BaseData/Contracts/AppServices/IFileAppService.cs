using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.AppServices
{
    public interface IFileAppService
    {
        Task<Guid> Add(FileDto dto, CancellationToken cancellationToken);
        Task<Guid> Update(FileDto dto, CancellationToken cancellationToken);
        Task<Guid> Delete(string id, CancellationToken cancellationToken);
        Task<List<FileDto>> GetAll(CancellationToken cancellationToken);
        Task<FileDto?> Get(string id, CancellationToken cancellationToken);
        Task<List<FileDto>> Search(string keyWord, CancellationToken cancellationToken);
    }
}

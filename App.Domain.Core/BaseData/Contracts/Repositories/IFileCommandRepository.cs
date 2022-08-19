using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IFileCommandRepository
    {
        Task<Guid> Add(FileDto dto, CancellationToken cancellationToken);
        Task<Guid> Update(FileDto dto, CancellationToken cancellationToken);
        Task<Guid> Delete(string id, CancellationToken cancellationToken);
    }
}

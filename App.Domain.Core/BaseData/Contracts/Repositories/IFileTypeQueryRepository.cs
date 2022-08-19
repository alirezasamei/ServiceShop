using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IFileTypeQueryRepository
    {
        Task<List<FileTypeDto>> GetAll(CancellationToken cancellationToken);
        Task<FileTypeDto> Get(int id, CancellationToken cancellationToken);
        Task<FileTypeDto> Get(string name, CancellationToken cancellationToken);
    }
}

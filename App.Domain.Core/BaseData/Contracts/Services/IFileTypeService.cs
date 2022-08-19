using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IFileTypeService
    {
        Task<int> Add(string name, string extention, CancellationToken cancellationToken);
        Task<int> Update(int id, string name, string extention, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<FileTypeDto>> GetAll(CancellationToken cancellationToken);
        Task<FileTypeDto> Get(int id, CancellationToken cancellationToken);
        Task<FileTypeDto> Get(string name, CancellationToken cancellationToken);
    }
}

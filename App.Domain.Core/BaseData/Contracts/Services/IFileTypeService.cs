using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IFileTypeService
    {
        Task<int> Add(string name);
        Task<int> Update(int id, string name);
        Task<int> Delete(int id);
        Task<List<FileTypeDto>> GetAll();
        Task<FileTypeDto> Get(int id);
        Task<FileTypeDto> Get(string name);
    }
}

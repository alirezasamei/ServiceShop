using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IFileService
    {
        Task<int> Add(FileDto dto);
        Task<int> Update(FileDto dto);
        Task<int> Delete(int id);
        Task<List<FileDto>> GetAll();
        Task<FileDto?> Get(int id);
        Task<FileDto?> Get(string userName);
    }
}

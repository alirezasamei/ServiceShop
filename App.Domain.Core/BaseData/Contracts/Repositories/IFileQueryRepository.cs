using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IFileQueryRepository
    {
        Task<List<FileDto>> GetAll();
        Task<FileDto?> Get(int id);
        Task<FileDto?> Get(string name);
    }
}

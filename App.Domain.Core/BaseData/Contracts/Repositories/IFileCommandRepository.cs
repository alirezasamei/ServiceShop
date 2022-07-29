using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IFileCommandRepository
    {
        Task<int> Add(FileDto dto);
        Task<int> Update(FileDto dto);
        Task<int> Delete(int id);
    }
}

using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IExpertServiceCommandRepository
    {
        Task<int> Add(ExpertServiceDto dto);
        Task<int> Update(ExpertServiceDto dto);
        Task<int> Delete(int id);
    }
}

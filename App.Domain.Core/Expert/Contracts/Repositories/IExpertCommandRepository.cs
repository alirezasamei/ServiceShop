using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IExpertCommandRepository
    {
        Task<int> Add(ExpertDto dto);
        Task<int> Update(ExpertDto dto);
        Task<int> Delete(int id);
    }
}

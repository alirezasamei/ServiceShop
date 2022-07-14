using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IExpertServiceFileCommandRepository
    {
        Task<int> Add(ExpertServiceFileDto dto);
        Task<int> Update(ExpertServiceFileDto dto);
        Task<int> Delete(int id);
    }
}

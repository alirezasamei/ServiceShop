using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IExpertQueryRepository
    {
        Task<List<ExpertDto>> GetAll();
        Task<ExpertDto?> Get(int appUserId);
    }
}

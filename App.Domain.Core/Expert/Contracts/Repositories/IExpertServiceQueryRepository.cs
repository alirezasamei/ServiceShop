using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IExpertServiceQueryRepository
    {
        Task<List<ExpertServiceDto>> GetAll();
        Task<ExpertServiceDto?> Get(int id);
    }
}

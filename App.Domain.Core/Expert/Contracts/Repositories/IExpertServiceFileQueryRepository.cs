using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IExpertServiceFileQueryRepository
    {
        Task<List<ExpertServiceFileDto>> GetAll();
        Task<ExpertServiceFileDto?> Get(int id);
        Task<ExpertServiceFileDto?> Get(string name);
    }
}

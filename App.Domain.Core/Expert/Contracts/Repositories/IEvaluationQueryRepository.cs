using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IEvaluationQueryRepository
    {
        Task<List<EvaluationDto>> GetAll();
        Task<EvaluationDto?> Get(int id);
    }
}

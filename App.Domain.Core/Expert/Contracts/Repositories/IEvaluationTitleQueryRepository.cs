using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IEvaluationTitleQueryRepository
    {
        Task<List<EvaluationTitleDto>> GetAll();
        Task<EvaluationTitleDto?> Get(int id);
        Task<EvaluationTitleDto?> Get(string Name);
    }
}

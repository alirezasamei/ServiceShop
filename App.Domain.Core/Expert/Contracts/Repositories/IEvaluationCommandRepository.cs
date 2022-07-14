using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IEvaluationCommandRepository
    {
        Task<int> Add(EvaluationDto dto);
        Task<int> Update(EvaluationDto dto);
        Task<int> Delete(int id);
    }
}

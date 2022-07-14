namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IEvaluationTitleCommandRepository
    {
        Task<int> Add(string title);
        Task<int> Update(int id, string Name);
        Task<int> Delete(int id);
    }
}

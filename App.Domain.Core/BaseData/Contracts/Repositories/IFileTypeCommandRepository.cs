namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IFileTypeCommandRepository
    {
        Task<int> Add(string name);
        Task<int> Update(int id, string name);
        Task<int> Delete(int id);
    }
}

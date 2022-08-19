namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IFileTypeCommandRepository
    {
        Task<int> Add(string name, string extention, CancellationToken cancellationToken);
        Task<int> Update(int id, string name, string extention, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}

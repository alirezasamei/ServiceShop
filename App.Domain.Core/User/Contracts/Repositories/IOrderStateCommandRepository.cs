using App.Domain.Core.User.Dtos;

namespace App.Domain.Core.User.Contracts.Repositories
{
    public interface IOrderStateCommandRepository
    {
        Task<int> Add(string name);
        Task<int> Update(int id, string name);
        Task<int> Delete(int id);
    }
}

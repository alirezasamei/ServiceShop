using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Customer.Contracts.Repositories
{
    public interface IOrderStateCommandRepository
    {
        Task<int> Add(string name);
        Task<int> Update(int id, string name);
        Task<int> Delete(int id);
    }
}

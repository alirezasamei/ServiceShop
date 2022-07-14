using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface IPastWorkCommandRepository
    {
        Task<int> Add(PastWorkDto dto);
        Task<int> Update(PastWorkDto dto);
        Task<int> Delete(int id);
    }
}

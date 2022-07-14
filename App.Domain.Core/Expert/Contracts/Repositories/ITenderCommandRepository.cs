using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface ITenderCommandRepository
    {
        Task<int> Add(TenderDto dto);
        Task<int> Update(TenderDto dto);
        Task<int> Delete(int id);
    }
}

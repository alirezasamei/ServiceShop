using App.Domain.Core.User.Dtos;

namespace App.Domain.Core.User.Contracts.Repositories
{
    public interface IUserCommandRepository
    {
        Task<int> Add(UserDto dto);
        Task<int> Update(UserDto dto);
        Task<int> Delete(int id);
    }
}

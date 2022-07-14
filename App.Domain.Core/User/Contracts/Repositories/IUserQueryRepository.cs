using App.Domain.Core.User.Dtos;

namespace App.Domain.Core.User.Contracts.Repositories
{
    public interface IUserQueryRepository
    {
        Task<List<UserDto>> GetAll();
        Task<UserDto?> Get(int id);
        Task<UserDto?> Get(string name);
    }
}

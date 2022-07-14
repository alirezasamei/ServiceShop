using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface ICommentQueryRepository
    {
        Task<List<CommentDto>> GetAll();
        Task<CommentDto?> Get(int id);
        Task<CommentDto?> Get(string title);
    }
}

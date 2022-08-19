using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface ICommentQueryRepository
    {
        Task<List<CommentDto>> GetAll(CancellationToken cancellationToken);
        Task<CommentDto?> Get(int id, CancellationToken cancellationToken);
        Task<CommentDto?> Get(string title, CancellationToken cancellationToken);
    }
}

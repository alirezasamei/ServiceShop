using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface ICommentCommandRepository
    {
        Task<int> Add(CommentDto dto, CancellationToken cancellationToken);
        Task<int> Update(CommentDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}

using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Services
{
    public interface ICommentService
    {
        Task<int> Add(CommentDto dto, CancellationToken cancellationToken);
        Task<int> Update(CommentDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetAll(CancellationToken cancellationToken);
        Task<CommentDto?> Get(int id, CancellationToken cancellationToken);
        Task<CommentDto?> Get(string title, CancellationToken cancellationToken);
    }
}

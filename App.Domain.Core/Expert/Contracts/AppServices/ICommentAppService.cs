using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.AppServices
{
    public interface ICommentAppService
    {
        Task<int> Add(CommentDto dto, CancellationToken cancellationToken);
        Task<int> Update(CommentDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetAll(string? keyWord, bool? isConfirmed, CancellationToken cancellationToken);
        Task<CommentDto?> Get(int id, CancellationToken cancellationToken);
        Task<CommentDto?> Get(string title, CancellationToken cancellationToken);
        Task ChangeConfirmState(int id, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetByExpertServiceId(int id, string keyWord, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetByCustomerId(int id, string keyWord, CancellationToken cancellationToken);
    }
}

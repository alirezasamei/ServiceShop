using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Core.Expert.Contracts.Repositories
{
    public interface ICommentCommandRepository
    {
        Task<int> Add(CommentDto dto);
        Task<int> Update(CommentDto dto);
        Task<int> Delete(int id);
    }
}

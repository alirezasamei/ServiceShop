using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Services.Expert
{
    public class CommentService : ICommentService
    {
        private readonly ICommentQueryRepository _commentQueryRepository;
        private readonly ICommentCommandRepository _commentCommandRepository;

        public CommentService(ICommentQueryRepository commentQueryRepository,
            ICommentCommandRepository commentCommandRepository)
        {
            _commentQueryRepository = commentQueryRepository;
            _commentCommandRepository = commentCommandRepository;
        }
        public async Task<int> Add(CommentDto dto, CancellationToken cancellationToken)
        {
            var id = await _commentCommandRepository.Add(dto, cancellationToken);
            return id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entityId = await _commentCommandRepository.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<CommentDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _commentQueryRepository.Get(id, cancellationToken);
            return dto;
        }

        public async Task<CommentDto?> Get(string title, CancellationToken cancellationToken)
        {
            var dto = await _commentQueryRepository.Get(title, cancellationToken);
            return dto;
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _commentQueryRepository.GetAll( cancellationToken);
            return dtos;
        }

        public async Task<int> Update(CommentDto dto, CancellationToken cancellationToken)
        {
            var id = await _commentCommandRepository.Update(dto, cancellationToken);
            return id;
        }
    }
}

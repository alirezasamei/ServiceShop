using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Expert.Entities;
using Microsoft.Extensions.Logging;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class CommentCommandRepository : ICommentCommandRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CommentCommandRepository> _logger;

        public CommentCommandRepository(AppDbContext context,
            ILogger<CommentCommandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Add(CommentDto dto, CancellationToken cancellationToken)
        {
            var entity = new Comment()
            {
                DislikeCount = dto.DislikeCount,
                ExpertServiceId = dto.ExpertServiceId,
                IsConfirmed = dto.IsConfirmed,
                LikeCount = dto.LikeCount,
                Text = dto.Text,
                Title = dto.Title,
                CustomerId = dto.CustomerId,
                SubmitDate = dto.SubmitDate,
            };
            await _context.Comments.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Comments.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                _logger.LogError("method {method} of repositoy {repository} is called by commentId: {wrongCommentId} that there is not in database",
                    nameof(Delete), nameof(CommentCommandRepository), id);
                throw new Exception("there is no comment with id: " + id);
            }
            _context.Comments.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(CommentDto dto, CancellationToken cancellationToken)
        {
            var entity = await _context.Comments.FirstOrDefaultAsync(e => e.Id == dto.Id);
            if (entity == null)
            {
                _logger.LogError("method {method} of repositoy {repository} is called by commentId: {wrongCommentId} that there is not in database",
                    nameof(Update), nameof(CommentCommandRepository), dto.Id);
                throw new Exception("there is no comment with id: " + dto.Id);
            }
            entity.DislikeCount = dto.DislikeCount;
            entity.ExpertServiceId = dto.ExpertServiceId;
            entity.IsConfirmed = dto.IsConfirmed;
            entity.LikeCount = dto.LikeCount;
            entity.Text = dto.Text;
            entity.Title = dto.Title;
            entity.CustomerId = dto.CustomerId;
            entity.SubmitDate = dto.SubmitDate;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}

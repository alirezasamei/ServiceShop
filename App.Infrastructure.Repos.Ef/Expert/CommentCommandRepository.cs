using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Expert.Entities;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class CommentCommandRepository : ICommentCommandRepository
    {
        private readonly AppDbContext _context;
        public CommentCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(CommentDto dto)
        {
            var entity = new Comment()
            {
                DislikeCount = dto.DislikeCount,
                ExpertServiceId = dto.ExpertServiceId,
                IsConfirmed = dto.IsConfirmed,
                LikeCount = dto.LikeCount,
                Text = dto.Text,
                Title = dto.Title,
                UserId = dto.UserId,
            };
            await _context.Comments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Comments.FirstOrDefaultAsync(e => e.Id == id);
            _context.Comments.Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(CommentDto dto)
        {
            var entity = await _context.Comments.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.DislikeCount = dto.DislikeCount;
            entity.ExpertServiceId = dto.ExpertServiceId;
            entity.IsConfirmed = dto.IsConfirmed;
            entity.LikeCount = dto.LikeCount;
            entity.Text = dto.Text;
            entity.Title = dto.Title;
            entity.UserId = dto.UserId;
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}

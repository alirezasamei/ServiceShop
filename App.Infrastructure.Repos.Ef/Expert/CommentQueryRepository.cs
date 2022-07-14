using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Expert
{
    public class CommentQueryRepository : ICommentQueryRepository
    {
        private readonly AppDbContext _context;
        public CommentQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CommentDto>> GetAll() =>
             await _context.Comments.Select(p => new CommentDto()
             {
                 Id = p.Id,
                 DislikeCount = p.DislikeCount,
                 ExpertServiceId = p.ExpertServiceId,
                 IsConfirmed = p.IsConfirmed,
                 LikeCount = p.LikeCount,
                 Text = p.Text,
                 Title = p.Title,
                 User = p.User.Name,
                 UserId = p.UserId,
             }).ToListAsync();

        public async Task<CommentDto?> Get(int id) =>
            await _context.Comments.Where(p => p.Id == id).Select(p => new CommentDto()
            {
                Id = p.Id,
                DislikeCount = p.DislikeCount,
                ExpertServiceId = p.ExpertServiceId,
                IsConfirmed = p.IsConfirmed,
                LikeCount = p.LikeCount,
                Text = p.Text,
                Title = p.Title,
                User = p.User.Name,
                UserId = p.UserId,
            }).FirstOrDefaultAsync();

        public async Task<CommentDto?> Get(string title) =>
            await _context.Comments.Where(p => p.Title == title).Select(p => new CommentDto()
            {
                Id = p.Id,
                DislikeCount = p.DislikeCount,
                ExpertServiceId = p.ExpertServiceId,
                IsConfirmed = p.IsConfirmed,
                LikeCount = p.LikeCount,
                Text = p.Text,
                Title = p.Title,
                User = p.User.Name,
                UserId = p.UserId,
            }).FirstOrDefaultAsync();
    }
}

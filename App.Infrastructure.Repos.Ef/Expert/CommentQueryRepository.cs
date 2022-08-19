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
        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken) =>
             await _context.Comments.Select(p => new CommentDto()
             {
                 Id = p.Id,
                 DislikeCount = p.DislikeCount,
                 Expert = p.ExpertService.Expert.AppUser.Name,
                 ExpertServiceId = p.ExpertServiceId,
                 IsConfirmed = p.IsConfirmed,
                 LikeCount = p.LikeCount,
                 Text = p.Text,
                 Title = p.Title,
                 Customer = p.Customer.AppUser.Name,
                 CustomerId = p.CustomerId,
                 Service = p.ExpertService.Service.Name,
                 SubmitDate = p.SubmitDate,
             }).ToListAsync(cancellationToken);

        public async Task<CommentDto?> Get(int id, CancellationToken cancellationToken) =>
            await _context.Comments.Where(p => p.Id == id).Select(p => new CommentDto()
            {
                Id = p.Id,
                DislikeCount = p.DislikeCount,
                Expert = p.ExpertService.Expert.AppUser.Name,
                ExpertServiceId = p.ExpertServiceId,
                IsConfirmed = p.IsConfirmed,
                LikeCount = p.LikeCount,
                Text = p.Text,
                Title = p.Title,
                Customer = p.Customer.AppUser.Name,
                CustomerId = p.CustomerId,
                Service = p.ExpertService.Service.Name,
                SubmitDate = p.SubmitDate,
            }).FirstOrDefaultAsync(cancellationToken);

        public async Task<CommentDto?> Get(string title, CancellationToken cancellationToken) =>
            await _context.Comments.Where(p => p.Title == title).Select(p => new CommentDto()
            {
                Id = p.Id,
                DislikeCount = p.DislikeCount,
                Expert = p.ExpertService.Expert.AppUser.Name,
                ExpertServiceId = p.ExpertServiceId,
                IsConfirmed = p.IsConfirmed,
                LikeCount = p.LikeCount,
                Text = p.Text,
                Title = p.Title,
                Customer = p.Customer.AppUser.Name,
                CustomerId = p.CustomerId,
                Service = p.ExpertService.Service.Name,
                SubmitDate = p.SubmitDate,
            }).FirstOrDefaultAsync(cancellationToken);
    }
}

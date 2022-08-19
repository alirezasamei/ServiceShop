using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.BaseData
{
    public class FileTypeCommandRepository : IFileTypeCommandRepository
    {
        private readonly AppDbContext _context;
        public FileTypeCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(string name, string extention, CancellationToken cancellationToken)
        {
            var entity = new FileType()
            {
                Name = name,
                Extention = extention,
                IsDeleted = false,
            };
            await _context.FileTypes.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.FileTypes.FirstOrDefaultAsync(e => e.Id == id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(int id, string name, string extention, CancellationToken cancellationToken)
        {
            var entity = await _context.FileTypes.FirstOrDefaultAsync(e => e.Id == id);
            entity.Name = name;
            entity.Extention = extention;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}

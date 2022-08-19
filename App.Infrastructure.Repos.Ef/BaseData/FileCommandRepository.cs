using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BaseDataEntities = App.Domain.Core.BaseData.Entities;

namespace App.Infrastructure.Repos.Ef.BaseData
{
    public class FileCommandRepository : IFileCommandRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<FileCommandRepository> _logger;

        public FileCommandRepository(AppDbContext context,
            ILogger<FileCommandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Guid> Add(FileDto dto, CancellationToken cancellationToken)
        {
            var entity = new BaseDataEntities.File()
            {
                CreationDate = dto.CreationDate,
                Description = dto.Description,
                ExpertServiceId = dto.ExpertServiceId,
                FileTypeId = dto.FileTypeId,
                IsDeleted = false,
                Name = dto.Name,
                ServiceId = dto.ServiceId,
            };
            await _context.Files.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<Guid> Delete(string id, CancellationToken cancellationToken)
        {
            var entity = await _context.Files.FirstOrDefaultAsync(e => e.Id.ToString() == id);
            if (entity == null)
            {
                _logger.LogError("method {method} of repositoy {repository} is called by fileId: {wrongId} that there is not in database",
                    nameof(Delete), nameof(FileCommandRepository), id);
                throw new Exception("there is no comment with id: " + id);
            }
            entity.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<Guid> Update(FileDto dto, CancellationToken cancellationToken)
        {
            var entity = await _context.Files.FirstOrDefaultAsync(e => e.Id == dto.Id);
            entity.CreationDate = dto.CreationDate;
            entity.Description = dto.Description;
            entity.ExpertServiceId = dto.ExpertServiceId;
            entity.FileTypeId = dto.FileTypeId;
            entity.Name = dto.Name;
            entity.ServiceId = dto.ServiceId;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}

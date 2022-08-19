using App.Domain.Core.Service.Contracts.Repositories;
using App.Domain.Core.Service.Dtos;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceEntities = App.Domain.Core.Service.Entities;

namespace App.Infrastructure.Repos.Ef.Service
{
    public class ServiceCommandRepository : IServiceCommandRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ServiceCommandRepository> _logger;

        public ServiceCommandRepository(AppDbContext context,
            ILogger<ServiceCommandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Add(ServiceDto dto, CancellationToken cancellationToken)
        {
            var entity = new ServiceEntities.Service()
            {
                CreationDate = dto.CreationDate,
                Description = dto.Description,
                ImageFileId = dto.ImageFileId,
                IsActive = dto.IsActive,
                IsDeleted = false,
                Name = dto.Name,
                ParentServiceId = dto.ParentServiceId,
                Price = dto.Price,
            };
            await _context.Services.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Services.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                _logger.LogError("method {method} of repositoy {repository} is called by serviceId: {wrongId} that there is not in database",
                    nameof(Delete), nameof(ServiceCommandRepository), id);
                throw new Exception("there is no comment with id: " + id);
            }
            entity.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(ServiceDto dto, CancellationToken cancellationToken)
        {
            var entity = await _context.Services.FirstOrDefaultAsync(e => e.Id == dto.Id);
            if (entity == null)
            {
                _logger.LogError("method {method} of repositoy {repository} is called by serviceId: {wrongId} that there is not in database",
                    nameof(Update), nameof(ServiceCommandRepository), dto.Id);
                throw new Exception("there is no comment with id: " + dto.Id);
            }
            entity.CreationDate = dto.CreationDate;
            entity.Description = dto.Description;
            entity.ImageFileId = dto.ImageFileId;
            entity.IsActive = dto.IsActive;
            entity.Name = dto.Name;
            entity.ParentServiceId = dto.ParentServiceId;
            entity.Price = dto.Price;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}

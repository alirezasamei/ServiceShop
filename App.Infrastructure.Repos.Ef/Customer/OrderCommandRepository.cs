using App.Domain.Core.Customer.Contracts.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Customer.Entities;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Infrastructure.Repos.Ef.Customer
{
    public class OrderCommandRepository : IOrderCommandRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public OrderCommandRepository(AppDbContext context,
            ILogger<OrderCommandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Add(OrderDto dto, CancellationToken cancellationToken)
        {
            var entity = new Order()
            {
                IsDeleted = false,
                OrderStateId = dto.OrderStateId,
                RegisterDate = dto.RegisterDate,
                ServiceId = dto.ServiceId,
                CustomerId = dto.CustomerId,
            };
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                _logger.LogError("method {method} of repositoy {repository} is called by orderId: {wrongId} that there is not in database",
                    nameof(Delete), nameof(OrderCommandRepository), id);
                throw new Exception("there is no comment with id: " + id);
            }
            entity.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(OrderDto dto, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.FirstOrDefaultAsync(e => e.Id == dto.Id);
            if (entity == null)
            {
                _logger.LogError("method {method} of repositoy {repository} is called by orderId: {wrongId} that there is not in database",
                    nameof(Update), nameof(OrderCommandRepository), dto.Id);
                throw new Exception("there is no comment with id: " + dto.Id);
            }
            entity.OrderStateId = dto.OrderStateId;
            //entity.RegisterDate = dto.RegisterDate;
            entity.ServiceId = dto.ServiceId;
            entity.CustomerId = dto.CustomerId;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> UpdateState(int orderId, int stateId, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.FirstOrDefaultAsync(e => e.Id == orderId);
            if (entity == null)
            {
                _logger.LogError("method {method} of repositoy {repository} is called by orderId: {wrongId} that there is not in database",
                    nameof(UpdateState), nameof(OrderCommandRepository), orderId);
                throw new Exception("there is no comment with id: " + orderId);
            }
            entity.OrderStateId = stateId;
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}

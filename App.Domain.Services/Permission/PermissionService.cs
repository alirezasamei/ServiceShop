using App.Domain.Core.Customer.Contracts.Services;
using App.Domain.Core.Permission.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Permission
{
    public class PermissionService : IPermissionService
    {
        private readonly IOrderService _orderService;

        public PermissionService(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<bool> HasPermissionDeleteOrder(int customerId, int orderId, CancellationToken cancellationToken)
        {
            var order = await _orderService.Get(orderId, cancellationToken);
            return order.CustomerId == customerId;
        }
    }
}

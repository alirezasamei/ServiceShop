namespace App.Domain.Core.Permission.Contracts.Services
{
    public interface IPermissionService
    {
        Task<bool> HasPermissionDeleteOrder(int customerId, int orderId, CancellationToken cancellationToken);
    }
}

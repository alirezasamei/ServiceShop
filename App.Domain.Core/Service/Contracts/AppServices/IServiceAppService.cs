using App.Domain.Core.Service.Dtos;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Service.Contracts.AppServices
{
    public interface IServiceAppService
    {
        Task<List<ServiceDto>> GetAll(string keyWord, CancellationToken cancellationToken);
        Task<ServiceDto?> Get(int id, CancellationToken cancellationToken);
        Task<ServiceDto?> Get(string name, CancellationToken cancellationToken);
        Task<int> Add(ServiceDto dto, IFormFile? serviceImage, CancellationToken cancellationToken);
        Task<int> Update(ServiceDto dto, IFormFile? userImage, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<ServiceDto>> GetByParentId(int? id, CancellationToken cancellationToken);
        Task<List<ServiceDto>> GetParentsByServiceId(int id, CancellationToken cancellationToken);
        Task<List<ServiceDto>> GetAll(CancellationToken cancellationToken);
    }
}

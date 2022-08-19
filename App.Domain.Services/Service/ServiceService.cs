using App.Domain.Core.Service.Contracts.Repositories;
using App.Domain.Core.Service.Contracts.Services;
using App.Domain.Core.Service.Dtos;

namespace App.Domain.Services.Service
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceQueryRepository _serviceQueryRepository;
        private readonly IServiceCommandRepository _serviceCommandRepository;

        public ServiceService(IServiceQueryRepository serviceQueryRepository,
        IServiceCommandRepository serviceCommandRepository)
        {
            _serviceQueryRepository = serviceQueryRepository;
            _serviceCommandRepository = serviceCommandRepository;
        }
        public async Task<int> Add(ServiceDto dto, CancellationToken cancellationToken)
        {
            var id = await _serviceCommandRepository.Add(dto, cancellationToken);
            return id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entityId = await _serviceCommandRepository.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<ServiceDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _serviceQueryRepository.Get(id, cancellationToken);
            dto.ImageUrl = dto.ImageFileId is null ? null : Path.Combine("Upload", Path.ChangeExtension(dto.ImageFileId.ToString(), Path.GetExtension(dto.ImageFileName)));
            return dto;
        }

        public async Task<ServiceDto?> Get(string name, CancellationToken cancellationToken)
        {
            var dto = await _serviceQueryRepository.Get(name, cancellationToken);
            dto.ImageUrl = dto.ImageFileId is null ? null : Path.Combine("Upload", Path.ChangeExtension(dto.ImageFileId.ToString(), Path.GetExtension(dto.ImageFileName)));
            return dto;
        }

        public async Task<List<ServiceDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _serviceQueryRepository.GetAll(cancellationToken);
            dtos.ForEach(d => d.ImageUrl = d.ImageFileId is null ? null : Path.Combine("Upload", Path.ChangeExtension(d.ImageFileId.ToString(), Path.GetExtension(d.ImageFileName))));
            return dtos;
        }

        public async Task<int> Update(ServiceDto dto, CancellationToken cancellationToken)
        {
            var entityId = await _serviceCommandRepository.Update(dto, cancellationToken);
            return entityId;
        }
    }
}

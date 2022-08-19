using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Services.BaseData
{
    public class FileService : IFileService
    {
        private readonly IFileQueryRepository _fileQueryRepository;
        private readonly IFileCommandRepository _fileCommandRepository;

        public FileService(IFileQueryRepository fileQueryRepository,
            IFileCommandRepository fileCommandRepository)
        {
            _fileQueryRepository = fileQueryRepository;
            _fileCommandRepository = fileCommandRepository;
        }
        public async Task<Guid> Add(FileDto dto, CancellationToken cancellationToken)
        {
            var id = await _fileCommandRepository.Add(dto, cancellationToken);
            return id;
        }

        public async Task<Guid> Delete(string id, CancellationToken cancellationToken)
        {
            var entityId = await _fileCommandRepository.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<FileDto?> Get(string id, CancellationToken cancellationToken)
        {
            var dto = await _fileQueryRepository.Get(id, cancellationToken);
            dto.FileUrl = Path.ChangeExtension(Path.Combine("Upload", dto.Name), dto.Extention);
            return dto;
        }

        public async Task<List<FileDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _fileQueryRepository.GetAll(cancellationToken);
            dtos.ForEach(d => d.FileUrl = Path.ChangeExtension(Path.Combine("Upload", d.Name), d.Extention));
            return dtos;
        }

        public async Task<Guid> Update(FileDto dto, CancellationToken cancellationToken)
        {
            var entityId = await _fileCommandRepository.Update(dto, cancellationToken);
            return entityId;
        }
    }
}

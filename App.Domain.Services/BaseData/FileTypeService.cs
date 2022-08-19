using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Services.BaseData
{
    public class FileTypeService : IFileTypeService
    {
        private readonly IFileTypeCommandRepository _fileTypeCommandRepository;
        private readonly IFileTypeQueryRepository _fileTypeQueryRepository;

        public FileTypeService(IFileTypeCommandRepository fileTypeCommandRepository,
            IFileTypeQueryRepository fileTypeQueryRepository)
        {
            _fileTypeCommandRepository = fileTypeCommandRepository;
            _fileTypeQueryRepository = fileTypeQueryRepository;
        }
        public async Task<int> Add(string name, string extention, CancellationToken cancellationToken)
        {
            int id = await _fileTypeCommandRepository.Add(name, extention, cancellationToken);
            return id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            int entityId = await _fileTypeCommandRepository.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<FileTypeDto> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _fileTypeQueryRepository.Get(id, cancellationToken);
            return dto;
        }

        public async Task<FileTypeDto> Get(string name, CancellationToken cancellationToken)
        {
            var dto = await _fileTypeQueryRepository.Get(name, cancellationToken);
            return dto;
        }

        public async Task<List<FileTypeDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _fileTypeQueryRepository.GetAll(cancellationToken);
            return dtos;
        }

        public async Task<int> Update(int id, string name, string extention, CancellationToken cancellationToken)
        {
            int entityId = await _fileTypeCommandRepository.Update(id, name, extention, cancellationToken);
            return entityId;
        }
    }
}

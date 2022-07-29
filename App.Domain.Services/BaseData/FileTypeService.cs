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
        public async Task<int> Add(string name)
        {
            int id = await _fileTypeCommandRepository.Add(name);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int entityId = await _fileTypeCommandRepository.Delete(id);
            return entityId;
        }

        public async Task<FileTypeDto> Get(int id)
        {
            var dto = await _fileTypeQueryRepository.Get(id);
            return dto;
        }

        public async Task<FileTypeDto> Get(string name)
        {
            var dto = await _fileTypeQueryRepository.Get(name);
            return dto;
        }

        public async Task<List<FileTypeDto>> GetAll()
        {
            var dtos = await _fileTypeQueryRepository.GetAll();
            return dtos;
        }

        public async Task<int> Update(int id, string name)
        {
            int entityId = await _fileTypeCommandRepository.Update(id, name);
            return entityId;
        }
    }
}

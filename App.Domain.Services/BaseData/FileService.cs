using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using Microsoft.AspNetCore.Identity;

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
        public async Task<int> Add(FileDto dto)
        {
            int id = await _fileCommandRepository.Add(dto);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int entityId = await _fileCommandRepository.Delete(id);
            return entityId;
        }

        public async Task<FileDto?> Get(int id)
        {
            var dto = await _fileQueryRepository.Get(id);
            return dto;
        }

        public async Task<FileDto?> Get(string userName)
        {
            var dto = await _fileQueryRepository.Get(userName);
            return dto;
        }

        public async Task<List<FileDto>> GetAll()
        {
            var dtos = await _fileQueryRepository.GetAll();
            return dtos;
        }

        public async Task<int> Update(FileDto dto)
        {
            int entityId = await _fileCommandRepository.Update(dto);
            return entityId;
        }
    }
}

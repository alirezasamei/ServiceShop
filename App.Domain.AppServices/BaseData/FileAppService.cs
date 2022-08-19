using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using Microsoft.Extensions.Logging;

namespace App.Domain.AppServices.BaseData
{
    public class FileAppService : IFileAppService
    {
        private readonly IFileService _fileService;
        private readonly ILogger<FileAppService> _logger;

        public FileAppService(IFileService fileService,
            ILogger<FileAppService> logger)
        {
            _fileService = fileService;
            _logger = logger;
        }
        public async Task<Guid> Add(FileDto dto, CancellationToken cancellationToken)
        {
            var id = await _fileService.Add(dto, cancellationToken);
            return id;
        }

        public async Task<Guid> Delete(string id, CancellationToken cancellationToken)
        {
            var entityId = await _fileService.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<FileDto?> Get(string id, CancellationToken cancellationToken)
        {
            var dto = await _fileService.Get(id, cancellationToken);
            if (dto == null)
            {
                _logger.LogError("method {method} of service {service} is called by fileId: {wrongCommentId} that there is not in database",
                    nameof(Get), nameof(IFileService), id);
                throw new Exception("there is no file with id: " + id);
            }
            return dto;
        }
        public async Task<List<FileDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _fileService.GetAll(cancellationToken);
            return dtos;
        }

        public async Task<List<FileDto>> Search(string keyWord, CancellationToken cancellationToken)
        {
            var dtos = await _fileService.GetAll(cancellationToken);
            if (keyWord == null)
                return dtos;
            keyWord = keyWord.ToLower();
            dtos = dtos.Where(d =>
            (d.ExpertService == null ? false : d.ExpertService.ToLower().Contains(keyWord)) ||
            (d.Service == null ? false : d.Service.ToLower().Contains(keyWord)) ||
            d.Name.ToLower().Contains(keyWord) ||
            (d.Description == null ? false : d.Description.ToLower().Contains(keyWord))).ToList();
            return dtos;
        }

        public async Task<Guid> Update(FileDto dto, CancellationToken cancellationToken)
        {
            var entityId = await _fileService.Update(dto, cancellationToken);
            return entityId;
        }
    }
}

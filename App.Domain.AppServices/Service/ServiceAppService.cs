using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Service.Contracts.AppServices;
using App.Domain.Core.Service.Contracts.Services;
using App.Domain.Core.Service.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
//using System.Text.Json;

namespace App.Domain.AppServices.Service
{
    public class ServiceAppService : IServiceAppService
    {
        private readonly IServiceService _serviceService;
        private readonly IFileService _fileService;
        private readonly IFileTypeService _fileTypeService;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger _logger;
        private readonly IDistributedCache _cache;

        public ServiceAppService(IServiceService serviceService,
            IFileService fileService,
            IFileTypeService fileTypeService,
            IWebHostEnvironment environment,
            ILogger<ServiceAppService> logger,
            IDistributedCache cache)
        {
            _serviceService = serviceService;
            _fileService = fileService;
            _fileTypeService = fileTypeService;
            _environment = environment;
            _logger = logger;
            _cache = cache;
        }

        public async Task<int> Add(ServiceDto dto, IFormFile? serviceImage, CancellationToken cancellationToken)
        {
            if (serviceImage != null)
            {
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "Upload");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                    _logger.LogInformation("Upload path was created :{uploadPath}", uploadsRootFolder);
                }
                FileDto fileDto = new()
                {
                    Name = Path.GetFileNameWithoutExtension(serviceImage.FileName),
                    CreationDate = DateTime.Now,
                };
                var fileType = await _fileTypeService.Get(serviceImage.ContentType, cancellationToken);
                if (fileType == null)
                {
                    fileDto.FileTypeId = await _fileTypeService.Add(serviceImage.ContentType, Path.GetExtension(serviceImage.FileName), cancellationToken);
                    _logger.LogInformation("an image with new fileType: {fileType} is going to upload", fileDto);
                }
                else
                    fileDto.FileTypeId = fileType.Id;
                dto.ImageFileId = await _fileService.Add(fileDto, cancellationToken);
                _logger.LogInformation("Image {imageDto} was added", dto);
                var filePath = Path.ChangeExtension(Path.Combine(uploadsRootFolder, dto.ImageFileId.ToString()), Path.GetExtension(serviceImage.FileName));
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await serviceImage.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
                }
            }
            dto.CreationDate = DateTime.Now;
            var id = await _serviceService.Add(dto, cancellationToken);
            return id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entityId = await _serviceService.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<ServiceDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _serviceService.Get(id, cancellationToken);
            return dto;
        }

        public async Task<ServiceDto?> Get(string name, CancellationToken cancellationToken)
        {
            var dto = await _serviceService.Get(name, cancellationToken);
            return dto;
        }

        public async Task<List<ServiceDto>> GetAll(string keyWord, CancellationToken cancellationToken)
        {
            var services = await GetAll(cancellationToken);
            if (keyWord is null or "")
            {
                return services;
            }
            keyWord = keyWord.ToLower();
            var filterServices = services.Where(s => s.Name.ToLower().Contains(keyWord) ||
            (s.Description is null ? false : s.Description.ToLower().Contains(keyWord))).ToList();
            return filterServices;
        }

        public async Task<List<ServiceDto>> GetAll(CancellationToken cancellationToken)
        {
            var bytesOfCachedValue = _cache.Get("AllServices");
            List<ServiceDto> services;
            if (bytesOfCachedValue != null)
            {
                services = JsonConvert.DeserializeObject<List<ServiceDto>>(Encoding.UTF8.GetString(bytesOfCachedValue));
                _logger.LogInformation("List of services has read from cache");
            }
            else
            {
                services = await _serviceService.GetAll(cancellationToken);
                _logger.LogInformation("List of services has read from database");
                var serializedValue = JsonConvert.SerializeObject(services);
                var bytesOfValue = Encoding.UTF8.GetBytes(serializedValue);
                _cache.Set("AllServices", bytesOfValue, new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1),
                });
            }
            if (services is null)
                _logger.LogWarning("something is wrong. result of {Service} is empty", "ServiceService");
            return services;
        }

        public async Task<List<ServiceDto>> GetByParentId(int? id, CancellationToken cancellationToken)
        {
            var dtos = await GetAll(cancellationToken);
            dtos = dtos.Where(d => d.ParentServiceId == id).ToList();
            return dtos;
        }

        public async Task<List<ServiceDto>> GetParentsByServiceId(int id, CancellationToken cancellationToken)
        {
            var dtos = await GetAll(cancellationToken);
            var dto = dtos.FirstOrDefault(dtos => dtos.Id == id);
            var parents = new List<ServiceDto>();
            while (dto.ParentServiceId != null)
            {
                dto = dtos.FirstOrDefault(d => d.Id == dto.ParentServiceId);
                parents.Add(dto);
            }
            return parents;
        }

        public async Task<int> Update(ServiceDto dto, IFormFile? serviceImage, CancellationToken cancellationToken)
        {
            if (serviceImage != null)
            {
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "Upload");
                if (!Directory.Exists(uploadsRootFolder))
                    Directory.CreateDirectory(uploadsRootFolder);
                FileDto fileDto = new()
                {
                    Name = Path.GetFileNameWithoutExtension(serviceImage.FileName),
                    CreationDate = DateTime.Now,
                };
                var fileType = await _fileTypeService.Get(serviceImage.ContentType, cancellationToken);
                if (fileType == null)
                    fileDto.FileTypeId = await _fileTypeService.Add(serviceImage.ContentType, Path.GetExtension(serviceImage.FileName), cancellationToken);
                else
                    fileDto.FileTypeId = fileType.Id;
                if (dto.ImageUrl != null)
                {
                    var fileFullPath = Path.ChangeExtension(Path.Combine(_environment.WebRootPath, dto.ImageUrl), Path.GetExtension(serviceImage.FileName));
                    if (File.Exists(fileFullPath))
                        File.Delete(fileFullPath);
                    fileDto.Id = (Guid)dto.ImageFileId!;
                    await _fileService.Update(fileDto, cancellationToken);
                }
                else
                {
                    dto.ImageFileId = await _fileService.Add(fileDto, cancellationToken);
                }
                var filePath = Path.ChangeExtension(Path.Combine(uploadsRootFolder, dto.ImageFileId.ToString()), Path.GetExtension(serviceImage.FileName));
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await serviceImage.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
                }
            }
            var result = await _serviceService.Update(dto, cancellationToken);
            return result;
        }
    }
}


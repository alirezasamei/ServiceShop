using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Enums;
using App.Domain.Core.ConfigurationModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace App.Domain.AppServices.BaseData
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _environment;
        private readonly IFileService _fileService;
        private readonly IFileTypeService _fileTypeService;
        private readonly IOptions<AppDomainOption> _options;
        private readonly ILogger<UserAppService> _logger;

        public UserAppService(IUserService appUserService,
         IWebHostEnvironment environment,
         IFileService fileService,
         IFileTypeService fileTypeService,
         IOptions<AppDomainOption> options,
         ILogger<UserAppService> logger)
        {
            _userService = appUserService;
            _environment = environment;
            _fileService = fileService;
            _fileTypeService = fileTypeService;
            _options = options;
            _logger = logger;
        }

        public async Task<IdentityResult> Register(AppUserDetailDto dto, CancellationToken cancellationToken)
        {
            dto.IsActive = true;
            dto.SubmitDate = DateTime.Now;
            dto.EmailConfirmed = false;
            dto.EmailConfirmed = false;
            return await _userService.Add(dto, cancellationToken);
        }

        public async Task<IdentityResult> Add(AppUserDetailDto dto, IFormFile userImage, CancellationToken cancellationToken)
        {
            if (userImage != null)
            {
                if (!Directory.Exists(_options.Value.UplaodPath))
                    Directory.CreateDirectory(_options.Value.UplaodPath);
                FileDto fileDto = new()
                {
                    Name = Path.GetFileNameWithoutExtension(userImage.FileName),
                    CreationDate = DateTime.Now,
                };
                var fileType = await _fileTypeService.Get(userImage.ContentType, cancellationToken);
                if (fileType == null)
                    fileDto.FileTypeId = await _fileTypeService.Add(userImage.ContentType, Path.GetExtension(userImage.FileName), cancellationToken);
                else
                    fileDto.FileTypeId = fileType.Id;
                dto.ImageFileId = await _fileService.Add(fileDto, cancellationToken);
                var filePath = Path.ChangeExtension(Path.Combine(_options.Value.UplaodPath, dto.ImageFileId.ToString()), Path.GetExtension(userImage.FileName));
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await userImage.CopyToAsync(fileStream).ConfigureAwait(false);
                }
            }
            dto.SubmitDate = DateTime.Now;
            var result = await _userService.Add(dto, cancellationToken);
            return result;
        }

        public async Task<IdentityResult> Delete(int id, CancellationToken cancellationToken)
        {
            return await _userService.Delete(id, cancellationToken);
        }

        public async Task<AppUserDetailDto?> Get(int id, CancellationToken cancellationToken)
        {
            return await _userService.Get(id, cancellationToken);
        }

        public async Task<AppUserDto?> Get(string userName, CancellationToken cancellationToken)
        {
            return await _userService.Get(userName, cancellationToken);
        }

        public async Task<List<AppUserDto>> GetAll(CancellationToken cancellationToken)
        {

            return await _userService.GetAll(cancellationToken);
        }

        public async Task<List<AppUserDto>> GetByRole(RoleEnum role, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAll(cancellationToken);
            return users.Where(u => u.Roles.Contains(role)).ToList();
        }

        public async Task<List<AppUserDto>> GetAll(string keyWord, CancellationToken cancellationToken)
        {
            _logger.LogTrace("Start method {methodName}", nameof(GetAll));
            var Users = await _userService.GetAll(cancellationToken);
            if (keyWord == null)
            {
                _logger.LogTrace("finish method {methodName} without any search keyWord", nameof(GetAll));
                return Users;
            }
            _logger.LogDebug("a search on keyWord : {keyWord} is performed", keyWord);
            keyWord = keyWord.ToLower();
            var filterUsers = Users.Where(u => u.Name.ToLower().Contains(keyWord) ||
            u.Email.ToLower().Contains(keyWord) || (string.IsNullOrEmpty(u.PhoneNumber) ? false : u.PhoneNumber.Contains(keyWord)) ||
            u.UserName.ToLower().Contains(keyWord)).ToList();
            _logger.LogTrace("finish method {methodName} with a search keyWord", nameof(GetAll));
            return filterUsers;
        }

        public async Task<IdentityResult> Update(AppUserDetailDto dto, IFormFile userImage, CancellationToken cancellationToken)
        {
            if (userImage != null)
            {
                if (!Directory.Exists(_options.Value.UplaodPath))
                    Directory.CreateDirectory(_options.Value.UplaodPath);
                FileDto fileDto = new()
                {
                    Name = Path.GetFileNameWithoutExtension(userImage.FileName),
                    CreationDate = DateTime.Now,
                };
                var fileType = await _fileTypeService.Get(userImage.ContentType, cancellationToken);
                if (fileType == null)
                    fileDto.FileTypeId = await _fileTypeService.Add(userImage.ContentType, Path.GetExtension(userImage.FileName), cancellationToken);
                else
                    fileDto.FileTypeId = fileType.Id;
                if (dto.ImageUrl != null)
                {
                    var fileFullPath = Path.Combine(_environment.WebRootPath, dto.ImageUrl);
                    if (File.Exists(fileFullPath))
                        File.Delete(fileFullPath);
                    fileDto.Id = (Guid)dto.ImageFileId!;
                    await _fileService.Update(fileDto, cancellationToken);
                }
                else
                {
                    dto.ImageFileId = await _fileService.Add(fileDto, cancellationToken);
                }
                var filePath = Path.ChangeExtension(Path.Combine(_options.Value.UplaodPath, dto.ImageFileId.ToString()), Path.GetExtension(userImage.FileName));
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await userImage.CopyToAsync(fileStream).ConfigureAwait(false);
                }
            }
            var result = await _userService.Update(dto, cancellationToken);
            return result;
        }

        public async Task<IdentityResult> Update(AppUserDetailDto dto, CancellationToken cancellationToken)
        {
            if (dto.Roles is null)
                dto.Roles = (await _userService.Get(dto.Id, cancellationToken)).Roles;
            var result = await _userService.Update(dto, cancellationToken);
            return result;
        }

        public async Task UpdatePicture(int id, IFormFile userImage, CancellationToken cancellationToken)
        {
            var dto = await _userService.Get(id, cancellationToken);
            if (!Directory.Exists(_options.Value.UplaodPath))
                Directory.CreateDirectory(_options.Value.UplaodPath);
            FileDto fileDto = new()
            {
                Name = Path.GetFileNameWithoutExtension(userImage.FileName),
                CreationDate = DateTime.Now,
            };
            var fileType = await _fileTypeService.Get(userImage.ContentType, cancellationToken);
            if (fileType == null)
                fileDto.FileTypeId = await _fileTypeService.Add(userImage.ContentType, Path.GetExtension(userImage.FileName), cancellationToken);
            else
                fileDto.FileTypeId = fileType.Id;
            if (dto.ImageUrl != null)
            {
                var fileFullPath = Path.Combine(_environment.WebRootPath, dto.ImageUrl);
                if (File.Exists(fileFullPath))
                    File.Delete(fileFullPath);
                fileDto.Id = (Guid)dto.ImageFileId!;
                await _fileService.Update(fileDto, cancellationToken);
            }
            else
            {
                dto.ImageFileId = await _fileService.Add(fileDto, cancellationToken);
            }
            var filePath = Path.ChangeExtension(Path.Combine(_options.Value.UplaodPath, dto.ImageFileId.ToString()), Path.GetExtension(userImage.FileName));
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await userImage.CopyToAsync(fileStream).ConfigureAwait(false);
            }
            var result = await _userService.Update(dto, cancellationToken);
        }
    }
}

using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace App.Domain.AppServices.BaseData
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _appUserService;
        private readonly IWebHostEnvironment _environment;
        private readonly IFileService _fileService;
        private readonly IFileTypeService _fileTypeService;
        private readonly ILogger<UserAppService> _logger;

        public UserAppService(IUserService appUserService,
         IWebHostEnvironment environment,
         IFileService fileService,
         IFileTypeService fileTypeService,
         ILogger<UserAppService> logger)
        {
            _appUserService = appUserService;
            _environment = environment;
            _fileService = fileService;
            _fileTypeService = fileTypeService;
            _logger = logger;
        }

        public async Task<IdentityResult> Register(AppUserDetailDto dto)
        {
            dto.IsActive = true;
            dto.SubmitDate = DateTime.Now;
            dto.EmailConfirmed = false;
            dto.EmailConfirmed = false;
            return await _appUserService.Add(dto);
        }

        public async Task<IdentityResult> Add(AppUserDetailDto dto, IFormFile UserImage)
        {
            if (UserImage != null)
            {
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "Upload");
                if (!Directory.Exists(uploadsRootFolder))
                    Directory.CreateDirectory(uploadsRootFolder);
                var fileName = Guid.NewGuid().ToString() + " " + UserImage.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await UserImage.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                FileDto fileDto = new()
                {
                    FileType = UserImage.ContentType,
                    NameWithExtention = fileName,
                    CreationDate = DateTime.Now,
                };
                var fileType = await _fileTypeService.Get(UserImage.ContentType);
                if (fileType == null)
                    fileDto.FileTypeId = await _fileTypeService.Add(UserImage.ContentType);
                else
                    fileDto.FileTypeId = fileType.Id;
                dto.ImageFileId = await _fileService.Add(fileDto);
            }
            dto.SubmitDate = DateTime.Now;
            var result = await _appUserService.Add(dto);
            return result;
        }

        public async Task<IdentityResult> Delete(int id)
        {
            return await _appUserService.Delete(id);
        }

        public async Task<AppUserDetailDto?> Get(int id)
        {
            return await _appUserService.Get(id);
        }

        public async Task<AppUserDto?> Get(string userName)
        {
            return await _appUserService.Get(userName);
        }

        public async Task<List<AppUserDto>> GetAll()
        {
            return await _appUserService.GetAll();
        }

        public async Task<List<AppUserDto>> GetAll(string keyWord)
        {
            _logger.LogTrace("Start method {methodName}", nameof(GetAll));
            var Users = await _appUserService.GetAll();
            if (keyWord == null)
            {
                _logger.LogTrace("finish method {methodName} without any search keyWord", nameof(GetAll));
                return Users;
            }
            _logger.LogDebug("a search on keyWord : {keyWord} is performed", keyWord);
            keyWord = keyWord.ToLower();
            var filterUsers = Users.Where(u => u.Name.ToLower().Contains(keyWord) ||
            u.Email.ToLower().Contains(keyWord) || u.PhoneNumber.Contains(keyWord) ||
            u.UserName.ToLower().Contains(keyWord)).ToList();
            _logger.LogTrace("finish method {methodName} with a search keyWord", nameof(GetAll));
            return filterUsers;
        }

        public async Task<IdentityResult> Update(AppUserDetailDto dto, IFormFile UserImage)
        {
            if (UserImage != null)
            {
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "Upload");
                if (!Directory.Exists(uploadsRootFolder))
                    Directory.CreateDirectory(uploadsRootFolder);
                var fileName = Guid.NewGuid().ToString() + " " + UserImage.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await UserImage.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                FileDto fileDto = new()
                {
                    FileType = UserImage.ContentType,
                    NameWithExtention = fileName,
                    CreationDate = DateTime.Now,
                };
                var fileType = await _fileTypeService.Get(UserImage.ContentType);
                if (fileType == null)
                    fileDto.FileTypeId = await _fileTypeService.Add(UserImage.ContentType);
                else
                    fileDto.FileTypeId = fileType.Id;
                if (dto.ImageUrl != null)
                {
                    var fileFullPath = Path.Combine(_environment.WebRootPath, dto.ImageUrl);
                    if (File.Exists(fileFullPath))
                        File.Delete(fileFullPath);
                    fileDto.Id = (int)dto.ImageFileId!;
                    dto.ImageFileId = await _fileService.Update(fileDto);
                }
                else
                    dto.ImageFileId = await _fileService.Add(fileDto);
            }
            dto.SubmitDate = DateTime.Now;
            var result = await _appUserService.Update(dto);
            return result;
        }
    }
}

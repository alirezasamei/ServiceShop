using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Enums;
using App.Domain.Core.Customer.Contracts.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace App.Domain.Services.BaseData
{
    public class UserService : IUserService
    {
        private readonly IAppUserCommandRepository _appUserCommandRepository;
        private readonly IAppUserQueryRepository _appUserQueryRepository;
        private readonly IExpertQueryRepository _expertQueryRepository;
        private readonly IExpertCommandRepository _expertCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IAppUserCommandRepository appUserCommandRepository,
            IAppUserQueryRepository appUserQueryRepository,
            IExpertQueryRepository expertQueryRepository,
            IExpertCommandRepository expertCommandRepository,
            ICustomerQueryRepository customerQueryRepository,
            ICustomerCommandRepository customerCommandRepository,
            IWebHostEnvironment environment,
            IMapper mapper,
            ILogger<UserService> logger)
        {
            _appUserCommandRepository = appUserCommandRepository;
            _appUserQueryRepository = appUserQueryRepository;
            _expertQueryRepository = expertQueryRepository;
            _expertCommandRepository = expertCommandRepository;
            _customerQueryRepository = customerQueryRepository;
            _customerCommandRepository = customerCommandRepository;
            _environment = environment;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<IdentityResult> Add(AppUserDetailDto dto)
        {
            var user = _mapper.Map<AppUserDto>(dto);
            var result = await _appUserCommandRepository.Add(user);
            dto.Id = user.Id;
            if (dto.Roles.Contains(RoleEnum.Expert))
                _expertCommandRepository.Add(_mapper.Map<ExpertDto>(dto));
            if (dto.Roles.Contains(RoleEnum.Customer))
                _customerCommandRepository.Add(_mapper.Map<CustomerDto>(dto));
            return result;
        }

        public async Task<IdentityResult> Delete(int id)
        {
            return await _appUserCommandRepository.Delete(id);

        }
        public async Task<AppUserDetailDto?> Get(int id)
        {
            var user = new AppUserDetailDto();
            var appuser = await _appUserQueryRepository.Get(id);
            _mapper.Map(appuser, user);
            if (user.Roles.Contains(RoleEnum.Expert))
            {
                var expert = await _expertQueryRepository.Get(id);
                if (expert != null)
                {
                    _mapper.Map(expert, user);
                    user.ImageUrl = expert.ImageFileName == null ? null : Path.Combine("Upload", expert.ImageFileName);
                }
            }
            if (user.Roles.Contains(RoleEnum.Customer))
            {
                var customer = await _customerQueryRepository.Get(id);
                if (customer != null)
                    _mapper.Map(customer, user);
            }
            return user;
        }

        public async Task<AppUserDto?> Get(string userName)
        {
            return await _appUserQueryRepository.Get(userName);
        }

        public async Task<List<AppUserDto>> GetAll()
        {
            _logger.LogTrace("Start method {methodName}", nameof(GetAll));
            var users = await _appUserQueryRepository.GetAll();
            _logger.LogTrace("finish method {methodName}", nameof(GetAll));
            return users;
        }

        public async Task<IdentityResult> Update(AppUserDetailDto dto)
        {
            return await _appUserCommandRepository.Update(dto);
        }
    }
}

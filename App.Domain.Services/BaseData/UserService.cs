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


        public async Task<IdentityResult> Add(AppUserDetailDto dto, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUserDto>(dto);
            var result = await _appUserCommandRepository.Add(user, cancellationToken);
            if (result.Succeeded)
            {
                dto.Id = user.Id;
                if (dto.Roles.Contains(RoleEnum.expert))
                    await _expertCommandRepository.Add(_mapper.Map<ExpertDto>(dto), cancellationToken);
                if (dto.Roles.Contains(RoleEnum.customer))
                    await _customerCommandRepository.Add(_mapper.Map<CustomerDto>(dto), cancellationToken);
            }
            return result;
        }

        public async Task<int> ConvertUserIdToCustomerId(int id, CancellationToken cancellationToken)
        {
            var customer = await _customerQueryRepository.Get(id, cancellationToken);
            return customer.Id;
        }

        public async Task<int> ConvertUserIdToExpertId(int id, CancellationToken cancellationToken)
        {
            var expert = await _expertQueryRepository.Get(id, cancellationToken);
            return expert.Id;
        }

        public async Task<IdentityResult> Delete(int id, CancellationToken cancellationToken)
        {
            return await _appUserCommandRepository.Delete(id, cancellationToken);

        }
        public async Task<AppUserDetailDto?> Get(int id, CancellationToken cancellationToken)
        {
            var user = new AppUserDetailDto();
            var appuser = await _appUserQueryRepository.Get(id, cancellationToken);
            _mapper.Map(appuser, user);
            if (user.Roles.Contains(RoleEnum.expert))
            {
                var expert = await _expertQueryRepository.Get(id, cancellationToken);
                if (expert != null)
                {
                    _mapper.Map(expert, user);
                    user.ImageUrl = expert.ImageFileId is null ? null : Path.Combine("Upload", Path.ChangeExtension(expert.ImageFileId.ToString(), Path.GetExtension(expert.ImageFileName)));
                }
            }
            if (user.Roles.Contains(RoleEnum.customer))
            {
                var customer = await _customerQueryRepository.Get(id, cancellationToken);
                if (customer != null)
                    _mapper.Map(customer, user);
            }
            return user;
        }

        public async Task<AppUserDto?> Get(string userName, CancellationToken cancellationToken)
        {
            return await _appUserQueryRepository.Get(userName, cancellationToken);
        }

        public async Task<List<AppUserDto>> GetAll(CancellationToken cancellationToken)
        {
            _logger.LogTrace("Start method {methodName}", nameof(GetAll));
            var users = await _appUserQueryRepository.GetAll();
            _logger.LogTrace("finish method {methodName}", nameof(GetAll));
            return users;
        }

        public async Task<IdentityResult> Update(AppUserDetailDto dto, CancellationToken cancellationToken)
        {
            if (dto.Roles.Contains(RoleEnum.expert))
                if (!await _expertQueryRepository.DoseExists(dto.Id, cancellationToken))
                {
                    await _expertCommandRepository.Add(_mapper.Map<ExpertDto>(dto), cancellationToken);
                }
                else
                {
                    await _expertCommandRepository.Update(_mapper.Map<ExpertDto>(dto), cancellationToken);
                }

            if (dto.Roles.Contains(RoleEnum.customer))
                if (!await _customerQueryRepository.DoseExists(dto.Id, cancellationToken))
                {
                    await _customerCommandRepository.Add(_mapper.Map<CustomerDto>(dto), cancellationToken);
                }
                else
                {
                    await _customerCommandRepository.Update(_mapper.Map<CustomerDto>(dto), cancellationToken);
                }

            return await _appUserCommandRepository.Update(dto, cancellationToken);
        }
    }
}

using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Expert.Dtos;
using AutoMapper;

namespace App.Domain.Services.Utilities
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<AppUserDetailDto, AppUserDto>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AppUserDetailDto, ExpertDto>().ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AppUserDetailDto, CustomerDto>().ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}

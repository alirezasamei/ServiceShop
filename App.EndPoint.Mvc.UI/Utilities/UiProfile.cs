using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Expert.Dtos;
using App.EndPoint.Mvc.UI.Areas.Admin.Models;
using AutoMapper;

namespace App.EndPoint.Mvc.UI.Utilities
{
    public class UiProfile : Profile
    {
        public UiProfile()
        {
            CreateMap<AppUserDetailDto, AppUserDto>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AppUserDetailDto, ExpertDto>().ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AppUserDetailDto, CustomerDto>().ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AppUserDto, AppUserDetailDto>();
            CreateMap<ExpertDto, AppUserDetailDto>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<CustomerDto, AppUserDetailDto>().ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AppUserDto, UserListViewModel>();
            CreateMap<AppUserDetailDto, UserDetailViewModel>();
            CreateMap<AppUserDetailDto, UserEditViewModel>();
            CreateMap<UserEditViewModel, AppUserDetailDto>();
            CreateMap<UserAddViewModel, AppUserDetailDto>();

            CreateMap<OrderDto, OrderViewModel>().ReverseMap();

            CreateMap<TenderDto, TenderViewModel>().ReverseMap();
        }
    }
}

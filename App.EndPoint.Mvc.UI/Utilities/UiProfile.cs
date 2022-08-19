using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Expert.Dtos;
using App.Domain.Core.Expert.Entities;
using App.Domain.Core.Service.Dtos;
using App.EndPoint.Mvc.UI.Models;
using AutoMapper;

namespace App.EndPoint.Mvc.UI.Utilities
{
    public class UiProfile : Profile
    {
        public UiProfile()
        {
            CreateMap<Tender, TenderDto>().ReverseMap();

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
            CreateMap<OrderDto, OrderForExpertDto>().ReverseMap();
            CreateMap<OrderForExpertDto, OrderForExpertViewModel>();

            CreateMap<TenderDto, TenderViewModel>().ReverseMap();
            CreateMap<TenderAndOrderDto, TenderWithOrderViewModel>();

            CreateMap<CommentDto, CommentViewModel>().ReverseMap();

            CreateMap<FileDto, FileViewModel>().ReverseMap();

            CreateMap<ServiceDto, ServiceViewModel>().ReverseMap();

            CreateMap<ExpertServiceDto, ExpertServiceViewModel>().ReverseMap();

            CreateMap<PastWorkDto, PastWorkViewModel>().ReverseMap();
        }
    }
}

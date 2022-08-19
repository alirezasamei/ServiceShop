using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoint.Mvc.UI.ViewComponents
{
    public class ExpertToolsViewComponent : ViewComponent
    {
        private readonly IUserAppService _userAppService;
        private readonly IMapper _mapper;

        public ExpertToolsViewComponent(IUserAppService userAppService,
            IMapper mapper)
        {
            _userAppService = userAppService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            if (this.HttpContext.User.FindAll(ClaimTypes.Role).Select(c => c.Value).Contains(RoleEnum.expert.ToString()))
            {
                return View("Index");
            }
            return View();
        }
    }
}

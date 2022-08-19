using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoint.Mvc.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoint.Mvc.UI.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        private readonly IUserAppService _userAppService;
        private readonly IMapper _mapper;

        public UserViewComponent(IUserAppService userAppService,
            IMapper mapper)
        {
            _userAppService = userAppService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (userId != 0)
            {
                var model = _mapper.Map<UserDetailViewModel>(await _userAppService.Get(userId, cancellationToken));
                return View("Index", model);
            }
            return View("Login");
        }
    }
}

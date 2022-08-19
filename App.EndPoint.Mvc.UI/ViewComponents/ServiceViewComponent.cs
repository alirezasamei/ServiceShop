using App.Domain.Core.Service.Contracts.AppServices;
using App.EndPoint.Mvc.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.Mvc.UI.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly IServiceAppService _serviceAppService;
        private readonly IMapper _mapper;

        public ServiceViewComponent(IServiceAppService serviceAppService,
            IMapper mapper)
        {
            _serviceAppService = serviceAppService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            List<ServiceViewModel> model = _mapper.Map<List<ServiceViewModel>>(await _serviceAppService.GetByParentId(null, cancellationToken));
            return View("Index", model);
        }
    }
}

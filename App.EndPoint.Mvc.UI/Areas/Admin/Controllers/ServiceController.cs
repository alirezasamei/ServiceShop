using App.Domain.Core.Service.Contracts.AppServices;
using App.Domain.Core.Service.Dtos;
using App.EndPoint.Mvc.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoint.Mvc.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceAppService _serviceAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(IServiceAppService serviceAppService,
            IMapper mapper,
            ILogger<ServiceController> logger)
        {
            _serviceAppService = serviceAppService;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index(string keyWord, CancellationToken cancellationToken)
        {
            var services = _mapper.Map<List<ServiceViewModel>>(await _serviceAppService.GetAll(keyWord, cancellationToken));
            return View(services);
        }

        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            ViewBag.Services = new SelectList(await _serviceAppService.GetAll(cancellationToken), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceViewModel model, IFormFile? serviceImage, CancellationToken cancellationToken)
        {
            if (serviceImage != null && !serviceImage.ContentType.Contains("image"))
            {
                ModelState.AddModelError(string.Empty, "فرمت عکس صحیح نیست.");
                _logger.LogInformation("a user with role {userRole} tried to upload a wrong format ({fileFformat}) image for service {serviceModel}",
                    "admin", serviceImage.ContentType, model);
            }
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<ServiceDto>(model);
                try
                {
                    var id = await _serviceAppService.Add(dto, serviceImage, cancellationToken);
                    _logger.LogInformation("user {Service} was added by admin", dto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ServiceViewModel>(await _serviceAppService.Get(id, cancellationToken));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceViewModel model, IFormFile? serviceImage, CancellationToken cancellationToken)
        {
            if (serviceImage != null && !serviceImage.ContentType.Contains("image"))
            {
                ModelState.AddModelError(string.Empty, "فرمت عکس صحیح نیست.");
                _logger.LogInformation("a user with role {userRole} tried to upload a wrong format ({fileFformat}) image for service {serviceModel}",
                    "admin", serviceImage.ContentType, model);
            }
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<ServiceDto>(model);
                try
                {
                    var id = await _serviceAppService.Update(dto, serviceImage, cancellationToken);
                    _logger.LogInformation("user {Service} was edited by admin", dto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _serviceAppService.Delete(id, cancellationToken);
                _logger.LogInformation("Service with id: {serviceId} was deleted by {userRole}", id, "admin");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

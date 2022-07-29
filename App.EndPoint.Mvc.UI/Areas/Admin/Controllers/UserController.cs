using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.BaseData.Enums;
using App.EndPoint.Mvc.UI.Areas.Admin.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace App.EndPoint.Mvc.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserAppService appUserAppService,
            SignInManager<AppUser> signInManager,
            IMapper mapper,
            ILogger<UserController> logger)
        {
            _userAppService = appUserAppService;
            _signInManager = signInManager;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ActionResult> Index(string keyWord, CancellationToken cancellationToken)
        {
            _logger.LogTrace("start method {methodName}", nameof(Index));
            ViewBag.UserName = this.User.FindFirstValue(ClaimTypes.Name);
            var model = _mapper.Map<List<UserListViewModel>>(await _userAppService.GetAll(keyWord));
            if (model.Count == 0)
                _logger.LogWarning("something is wrong. result of {AppService} is empty", "UserAppService");
            else
                _logger.LogDebug("count of model is {modelCount}", model.Count);
            _logger.LogTrace("finish method {methodName}", nameof(Index));
            return View(model);
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            ViewBag.UserName = this.User.FindFirstValue(ClaimTypes.Name);
            var model = _mapper.Map<UserDetailViewModel>(await _userAppService.Get(id));
            return View(model);
        }

        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            ViewBag.UserName = this.User.FindFirstValue(ClaimTypes.Name);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserAddViewModel model, IFormFile? userImage, CancellationToken cancellationToken)
        {
            if (userImage != null && !userImage.ContentType.Contains("image"))
                ModelState.AddModelError(string.Empty, "فرمت عکس صحیح نیست.");
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<AppUserDetailDto>(model);
                var result = await _userAppService.Add(dto, userImage);
                if (result.Succeeded)
                {
                    _logger.LogInformation("user {User} was added by admin", dto);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, item.Description);
                    }
                    return View(model);
                }
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            ViewBag.UserName = this.User.FindFirstValue(ClaimTypes.Name);
            var model = _mapper.Map<UserEditViewModel>(await _userAppService.Get(id));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditViewModel model, IFormFile? userImage, CancellationToken cancellationToken)
        {
            if (userImage != null && !userImage.ContentType.Contains("image"))
                ModelState.AddModelError(string.Empty, "فرمت عکس صحیح نیست.");
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<AppUserDetailDto>(model);
                var result = await _userAppService.Update(dto, userImage);
                if (result.Succeeded)
                {
                    _logger.LogInformation("user {User} was added by admin", dto);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, item.Description);
                    }
                    return View(model);
                }
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _userAppService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

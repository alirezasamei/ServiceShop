using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.EndPoint.Mvc.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        public UserController(IUserAppService userAppService,
            SignInManager<AppUser> signInManager,
            IMapper mapper,
            ILogger<UserController> logger)
        {
            _userAppService = userAppService;
            _signInManager = signInManager;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ActionResult> Index(string keyWord, CancellationToken cancellationToken)
        {
            _logger.LogTrace("start method {methodName}", nameof(Index));

            var dtos = await _userAppService.GetAll(keyWord, cancellationToken);
            var model = _mapper.Map<List<UserListViewModel>>(dtos);
            _logger.LogInformation("List of users has read from database");
            if (model.Count == 0)
                _logger.LogWarning("something is wrong. result of {appService} is empty", "UserAppService");
            else
                _logger.LogDebug("count of model is {modelCount}", model.Count);
            _logger.LogTrace("finish method {methodName}", nameof(Index));
            return View(model);
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<UserDetailViewModel>(await _userAppService.Get(id, cancellationToken));
            return View(model);
        }

        public IActionResult Create()
        {
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
                var result = await _userAppService.Add(dto, userImage, cancellationToken);
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
            var model = _mapper.Map<UserEditViewModel>(await _userAppService.Get(id, cancellationToken));
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
                var result = await _userAppService.Update(dto, userImage, cancellationToken);
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
            await _userAppService.Delete(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}

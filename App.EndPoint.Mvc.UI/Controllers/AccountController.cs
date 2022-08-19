using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.BaseData.Enums;
using App.EndPoint.Mvc.UI.Models.BaseData;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoint.Mvc.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserAppService _userAppService;
        private readonly IMapper _mapper;

        public AccountController(SignInManager<AppUser> signInManager,
                IUserAppService userAppService,
                IMapper mapper)
        {
            _signInManager = signInManager;
            _userAppService = userAppService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            await _signInManager.SignOutAsync();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel model, string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return LocalRedirect(ReturnUrl == null ? "~/" : ReturnUrl);
                }

                ModelState.AddModelError(string.Empty, "خطا در فرآیند لاگین");
            }
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("~/");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Register(CancellationToken cancellationToken, RoleEnum role = RoleEnum.customer)
        {
            var isCutomer = this.User.IsInRole(RoleEnum.customer.ToString());
            var isExpert = this.User.IsInRole(RoleEnum.expert.ToString());
            if (isCutomer && !isExpert)
            {
                return View(nameof(AddRole), RoleEnum.expert);
            }
            if (isExpert && !isCutomer)
            {
                return View(nameof(AddRole), RoleEnum.customer);
            }
            if (isCutomer && isExpert)
                return LocalRedirect("~/");
            return View(new UserRegisterViewModel { Role = role });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel model,CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var dto = new AppUserDetailDto
                {
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Roles = new() { model.Role },
                    Password = model.Password,
                };

                var result = await _userAppService.Register(dto, cancellationToken);
                if (result.Succeeded)
                {
                    await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);
                    return LocalRedirect("~/");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult AddRole(RoleEnum role)
        {
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(RoleEnum role, CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _userAppService.Get(id, cancellationToken);
            user.Roles.Add(role);
            var result = await _userAppService.Update(user, cancellationToken);
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction(nameof(Login));
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
            }
            return View(role);
        }
    }
}

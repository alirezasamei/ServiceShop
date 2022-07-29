using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.BaseData.Enums;
using App.EndPoint.Mvc.UI.Models.BaseData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.Mvc.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserAppService _appUserAppService;

        public AccountController(SignInManager<AppUser> signInManager,
                IUserAppService appUserAppService)
        {
            _signInManager = signInManager;
            _appUserAppService = appUserAppService;
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
        public IActionResult Register(RoleEnum role = RoleEnum.Customer)
        {
            return View(new UserRegisterViewModel { Role = role });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
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

                var result = await _appUserAppService.Register(dto);
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

    }
}

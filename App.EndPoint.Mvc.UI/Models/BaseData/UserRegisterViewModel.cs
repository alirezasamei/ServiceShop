using App.Domain.Core.BaseData.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Models.BaseData
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [StringLength(100, ErrorMessage = "{0} حداقل {1} کاراکتر و حداکتر {2} باشد", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Compare(nameof(Password), ErrorMessage = "رمز عبور و تکرار رمز عبور باید یکسان باشند")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name ="شماره تلفن")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [Display(Name ="نام و نام خانوادگی")]
        public string Name { get; set; }

        public RoleEnum Role { get; set; }
    }
}

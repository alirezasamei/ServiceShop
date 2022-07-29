using App.Domain.Core.BaseData.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Areas.Admin.Models
{
    public class UserAddViewModel
    {
        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [StringLength(100, ErrorMessage = "{0} حداقل {1} کاراکتر و حداکتر {2} باشد", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [Display(Name = "تکرار رمز عبور")]
        [Compare(nameof(Password), ErrorMessage = "رمز عبور و تکرار رمز عبور باید یکسان باشند")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "شماره تلفن")]
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [Display(Name = "نام و نام خانوادگی")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [Display(Name ="نوع کاربری")]
        public List<RoleEnum> Roles { get; set; }

        [Display(Name="وضعبت کاربر")]
        public bool IsActive { get; set; }

        [Display(Name ="آدرس")]
        public string? Address { get; set; }
    }
}

using App.Domain.Core.BaseData.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Models
{
    public class UserEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        [Display(Name = "شماره تلفن")]
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است.")]
        [Display(Name = "نام و نام خانوادگی")]
        public string Name { get; set; }

        [Display(Name ="نوع کاربری")]
        public List<RoleEnum>? Roles { get; set; }

        [Display(Name="وضعبت کاربر")]
        public bool IsActive { get; set; }

        [Display(Name ="آدرس")]
        public string? Address { get; set; }

        [Display(Name = "تصویر پروفایل")]
        public string? ImageUrl { get; set; }
        public Guid? ImageFileId { get; set; }
    }
}

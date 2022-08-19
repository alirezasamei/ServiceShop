using App.Domain.Core.BaseData.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Models
{
    public class UserDetailViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name ="رمز عبور")]
        public string Password { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name ="تایید ایمیل")]
        public bool EmailConfirmed { get; set; }
        
        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }

        [Display(Name ="تایید شماره تلفن")]
        public bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string Name { get; set; }

        [Display(Name = "نوع کاربری")]
        public List<RoleEnum> Roles { get; set; }

        [Display(Name ="تاریخ ثبت نام")]
        public DateTime SubmitDate { get; set; }
        
        [Display(Name ="فعال")]
        public bool IsActive { get; set; }

        [Display(Name ="آدرس")]
        public string? Address { get; set; }

        [Display(Name ="تصویر پروفایل")]
        public string? ImageUrl { get; set; }
    }
}

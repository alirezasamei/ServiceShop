using App.Domain.Core.BaseData.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Areas.Admin.Models
{
    public class UserListViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }


        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string Name { get; set; }

        [Display(Name = "وضعیت کاربر")]
        public bool IsActive { get; set; }

        [Display(Name = "تاریخ عضویت")]
        public DateTime SubmitDate { get; set; }


        [Display(Name = "نوع کاربری")]
        public List<RoleEnum> Roles { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Models
{
    public class ServiceViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "وارد کردن فیلد {0} الزامی است")]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "سرویس اصلی")]
        public int? ParentServiceId { get; set; }

        [Display(Name = "سرویس مادر")]
        public string? ParentService { get; set; }

        [Display(Name = "قیمت (تومان)")]
        public long? Price { get; set; }

        public Guid? ImageFileId { get; set; }
        public string? ImageFileName { get; set; }
        [Display(Name = "تصویر")]
        public string? ImageUrl { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }
    }
}

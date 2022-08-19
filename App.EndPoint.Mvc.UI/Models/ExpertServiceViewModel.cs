using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Models
{
    public class ExpertServiceViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "وارد کردن فیلد {0} الزامی است")]
        [Display(Name = "متخصص")]
        public int ExpertId { get; set; }

        [Display(Name = "متخصص")]
        public string? Expert { get; set; }

        [Required(ErrorMessage = "وارد کردن فیلد {0} الزامی است")]
        [Display(Name = "سرویس")]
        public int ServiceId { get; set; }

        [Display(Name = "سرویس")]
        public string? Service { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "تعداد کامنت")]
        public int? CommentsCount { get; set; }
    }
}

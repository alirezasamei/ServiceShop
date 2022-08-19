using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        [Display(Name = "مشتری")]
        public string? Customer { get; set; }

        [Required(ErrorMessage = "وارد کردن فیلد {0} الزامی است")]
        [Display(Name = "سرویس")]
        public int ServiceId { get; set; }

        [Display(Name = "سرویس")]
        public string? Service { get; set; }

        [Display(Name = "وضعیت سفارش")]
        public string? OrderState { get; set; }
        public int? OrderStateId { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime? RegisterDate { get; set; }

        [Display(Name = "تعداد پیشنهادها")]
        public int? TendersCount { get; set; }
    }
}

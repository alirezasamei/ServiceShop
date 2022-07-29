using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Areas.Admin.Models
{
    public class TenderViewModel
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }

        [Display(Name = "متخصص")]
        public string Expert { get; set; }
        public int OrderId { get; set; }

        [Display(Name = "قیمت")]
        public long? Price { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "زمان لازم")]
        public TimeSpan? RequiredTime { get; set; }

        [Display(Name = "زمان شروع")]
        public DateTime? StartDate { get; set; }
    }
}

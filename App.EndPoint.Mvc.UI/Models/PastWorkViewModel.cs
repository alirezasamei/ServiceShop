using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Models
{
    public class PastWorkViewModel
    {
        public int Id { get; set; }

        [Display(Name ="مشتری")]
        public int CustomerId { get; set; }

        [Display(Name ="مشتری")]
        public string Customer { get; set; }
        public int ExpertServiceId { get; set; }
        
        [Display(Name ="متخصص")]
        public string Expert { get; set; }

        [Display(Name ="سرویس")]
        public string Service { get; set; }

        [Display(Name ="قیمت (تومان)")]
        public long? Price { get; set; }

        [Display(Name ="تاریخ انجام کار")]
        public DateTime? ComplitionDate { get; set; }
    }
}

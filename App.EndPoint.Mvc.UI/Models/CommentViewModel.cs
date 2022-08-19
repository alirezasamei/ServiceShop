using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "وارد کردن فیلد {0} الزامی است")]
        [Display(Name ="متخصص/سرویس")]
        public int ExpertServiceId { get; set; }

        [Display(Name ="متخصص")]
        public string? Expert { get; set; }

        [Display(Name ="سرویس")]
        public string? Service { get; set; }
        public int CustomerId { get; set; }

        [Display(Name ="مشتری")]
        public string? Customer { get; set; }

        [Required(ErrorMessage = "وارد کردن فیلد {0} الزامی است")]
        [Display(Name ="عنوان")]
        public string Title { get; set; }

        [Display(Name ="توضیحات")]
        public string? Text { get; set; }

        [Display(Name ="تعداد موافق")]
        public int LikeCount { get; set; } = 0;

        [Display(Name ="تعداد مخالف")]
        public int DislikeCount { get; set; } = 0;

        [Display(Name ="تایید شده")]
        public bool IsConfirmed { get; set; }
    }
}

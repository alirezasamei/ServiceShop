using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.UI.Models
{
    public class FileViewModel
    {
        public Guid Id { get; set; }
        public string? ExpertService { get; set; }

        [Display(Name ="متخصص/سرویس")]
        public int? ExpertServiceId { get; set; }
        public string? Service { get; set; }

        [Display(Name ="سرویس")]
        public int? ServiceId { get; set; }

        [Display(Name = "تصویر")]
        public string? FileUrl { get; set; }

        [Display(Name = "نام فایل")]
        public string NameWithExtention { get; set; }
        public string? FileType { get; set; }

        [Display(Name = "نوع فایل")]
        public int FileTypeId { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
    }
}

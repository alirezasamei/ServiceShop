using System.ComponentModel.DataAnnotations;
using CustomerEntities = App.Domain.Core.Customer.Entities;

namespace App.Domain.Core.Expert.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int ExpertServiceId { get; set; }
        public ExpertService ExpertService { get; set; }
        public int CustomerId { get; set; }
        public CustomerEntities.Customer Customer { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(1000)]
        public string? Text { get; set; }
        public DateTime SubmitDate { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public bool IsConfirmed { get; set; }
    }
}

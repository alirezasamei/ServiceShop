namespace App.Domain.Core.Expert.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int ExpertServiceId { get; set; }
        public string Expert { get; set; }
        public string Service { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
        public DateTime SubmitDate { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public bool IsConfirmed { get; set; }
    }
}

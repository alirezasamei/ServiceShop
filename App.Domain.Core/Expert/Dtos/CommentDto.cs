namespace App.Domain.Core.Expert.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int ExpertServiceId { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public bool IsConfirmed { get; set; }
    }
}

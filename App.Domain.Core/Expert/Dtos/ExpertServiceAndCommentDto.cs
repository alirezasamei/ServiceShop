namespace App.Domain.Core.Expert.Dtos
{
    public class ExpertServiceAndCommentDto
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public string Expert { get; set; }
        public int ServiceId { get; set; }
        public string Service { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public List<CommentDto> Comments { get; set; }
    }

}

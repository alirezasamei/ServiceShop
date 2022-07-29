namespace App.Domain.Core.Expert.Dtos
{
    public class ExpertDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int? ImageFileId { get; set; }
        public string? ImageFileName { get; set; }
        public string? Address { get; set; }
    }
}

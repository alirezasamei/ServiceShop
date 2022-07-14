namespace App.Domain.Core.Expert.Dtos
{
    public class ExpertServiceFileDto
    {
        public int Id { get; set; }
        public int ExpertServiceId { get; set; }
        public string NameWithExtention { get; set; }
        public int FileTypeId { get; set; }
        public string FileType { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }

}

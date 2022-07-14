namespace App.Domain.Core.Service.Dtos
{
    public class ServiceFileDto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string Service { get; set; }
        public string NameWithExtention { get; set; }
        public int FileTypeId { get; set; }
        public string FileType { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

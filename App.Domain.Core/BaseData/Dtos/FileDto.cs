namespace App.Domain.Core.BaseData.Dtos
{
    public class FileDto
    {
        public Guid Id { get; set; }
        public string? ExpertService { get; set; }
        public int? ExpertServiceId { get; set; }
        public string? Service { get; set; }
        public int? ServiceId { get; set; }
        public string FileUrl { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public string FileType { get; set; }
        public int FileTypeId { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

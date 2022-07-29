namespace App.Domain.Core.Service.Dtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentServiceId { get; set; }
        public string? ParentService { get; set; }
        public long? Price { get; set; }
        public int? ImageFileId { get; set; }
        public string? ImageFileName { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}

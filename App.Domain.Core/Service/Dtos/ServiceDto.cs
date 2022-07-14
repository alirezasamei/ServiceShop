namespace App.Domain.Core.Service.Dtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentSrviceId { get; set; }
        public string? ParentService { get; set; }
        public long? Price { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}

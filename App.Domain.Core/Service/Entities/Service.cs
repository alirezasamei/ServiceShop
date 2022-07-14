using App.Domain.Core.Expert.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Service.Entities
{
    public class Service
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int? ParentSrviceId { get; set; }
        public Service? ParentService { get; set; }
        public long? Price { get; set; }
        [StringLength(50)]
        public string? ImageName { get; set; }
        [StringLength(2000)]
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public List<ExpertService> ExpertServices { get; set; }
        public List<ServiceFile> ServiceFiles { get; set; }
    }
}

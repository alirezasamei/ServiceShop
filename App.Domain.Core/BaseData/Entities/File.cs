using App.Domain.Core.Expert.Entities;
using ServiceEntities = App.Domain.Core.Service.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.BaseData.Entities
{
    public class File
    {
        public int Id { get; set; }
        public int? ExpertServiceId { get; set; }
        public ExpertService? ExpertService { get; set; }
        public int? ServiceId { get; set; }
        public ServiceEntities.Service? Service { get; set; }
        [StringLength(50)]
        public string NameWithExtention { get; set; }
        public int FileTypeId { get; set; }
        public FileType FileType { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

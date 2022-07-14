using App.Domain.Core.BaseData.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Service.Entities
{
    public class ServiceFile
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
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

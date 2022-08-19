using BaseDataEntity = App.Domain.Core.BaseData.Entities;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Expert.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Service.Entities
{
    public class Service
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int? ParentServiceId { get; set; }
        public Service? ParentService { get; set; }
        public long? Price { get; set; }
        public BaseDataEntity.File? ImageFile { get; set; }
        public Guid? ImageFileId { get; set; }
        [StringLength(2000)]
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public List<ExpertService> ExpertServices { get; set; }
        public List<BaseData.Entities.File> ServiceFiles { get; set; }
    }
}

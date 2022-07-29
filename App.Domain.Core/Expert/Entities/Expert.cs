using BaseDataEntity = App.Domain.Core.BaseData.Entities;
using System.ComponentModel.DataAnnotations;
using App.Domain.Core.BaseData.Entities;

namespace App.Domain.Core.Expert.Entities
{
    public class Expert
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser appUser { get; set; }
        public BaseDataEntity.File? ImageFile { get; set; }
        public int? ImageFileId { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }

        public List<ExpertService> ExpertServices { get; set; }
        public List<Tender> Tenders { get; set; }
    }
}

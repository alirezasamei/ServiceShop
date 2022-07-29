using App.Domain.Core.BaseData.Entities;
using ServiceEntities = App.Domain.Core.Service.Entities;

namespace App.Domain.Core.Expert.Entities
{
    public class ExpertService
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
        public int ServiceId { get; set; }
        public ServiceEntities.Service Service { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public List<Comment> Comments { get; set; }
        public List<BaseData.Entities.File> expertServiceFiles { get; set; }
        public List<PastWork> PastWorks { get; set; }
        public List<Evaluation> Evaluations { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace App.Domain.Core.Expert.Entities
{
    public class Expert
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(11)]
        public string? Mobile { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string? ImageName { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }
        public DateTime SubmitDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public List<ExpertService> ExpertServices { get; set; }
        public List<Tender> Tenders { get; set; }
    }
}

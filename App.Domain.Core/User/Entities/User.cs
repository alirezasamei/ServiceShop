using App.Domain.Core.Expert.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.User.Entities
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(11)]
        public string? Mobile { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }
        public DateTime SubmitDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Order> Orders { get; set; }
        public List<PastWork> PastWorks { get; set; }
    }
}

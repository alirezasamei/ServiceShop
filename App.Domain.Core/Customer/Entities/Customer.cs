using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Expert.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Customer.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Order> Orders { get; set; }
        public List<PastWork> PastWorks { get; set; }
    }
}

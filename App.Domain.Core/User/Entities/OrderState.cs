using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.User.Entities
{
    public class OrderState
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}

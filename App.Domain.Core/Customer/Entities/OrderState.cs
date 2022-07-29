using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Customer.Entities
{
    public class OrderState
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}

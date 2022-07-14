using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Operator.Entities
{
    public class Operator
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(11)]
        public string? Mobile { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public DateTime SubmitDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}

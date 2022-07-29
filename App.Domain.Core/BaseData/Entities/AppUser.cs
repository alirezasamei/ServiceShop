using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.BaseData.Entities
{
    public class AppUser : IdentityUser<int>
    {
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime SubmitDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}

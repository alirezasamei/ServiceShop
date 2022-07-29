using App.Domain.Core.BaseData.Enums;

namespace App.Domain.Core.BaseData.Dtos
{
    public class AppUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string Name { get; set; }
        public List<RoleEnum> Roles { get; set; }
        public DateTime SubmitDate { get; set; }
        public bool IsActive { get; set; }
    }
}

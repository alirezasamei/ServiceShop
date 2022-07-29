using App.Domain.Core.BaseData.Enums;

namespace App.Domain.Core.BaseData.Dtos
{
    public class AppUserUpdateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public List<RoleEnum> Roles { get; set; }
    }
}

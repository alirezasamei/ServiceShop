using Microsoft.AspNetCore.Identity;

namespace App.EndPoint.Mvc.UI.Utilities
{
    public class PersianDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = $"نام کاربری {userName} قبلا استفاده شده است!",
            };
        }
    }
}

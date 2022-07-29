using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Enums
{
    public enum RoleEnum : int
    {
        [Display(Name ="ادمین")]
        Admin = 1,
        [Display(Name ="متخصص")]
        Expert = 2,
        [Display(Name ="مشتری")]
        Customer = 3,
    }
}

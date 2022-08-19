using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Customer.Enums
{
    public enum OrderStateEnum : int
    {
        [Display(Name = "منتظر پیشنهاد متخصص")]
        WaitingForTender = 1,

        [Display(Name = "منتظر انتخاب متخصص")]
        WaitingForChoseExpert = 2,

        [Display(Name = "منتظر آمدن متخصص")]
        WaitingForArriveExpert = 3,

    }
}

using System.Globalization;
namespace App.EndPoint.Mvc.UI.Utilities
{
    public static class PersianDate
    {
        public static string ToShamsi(this DateTime gregorianDate)
        {
            PersianCalendar pc = new();
            return pc.GetYear(gregorianDate) + "/" + pc.GetMonth(gregorianDate) + "/" + pc.GetDayOfMonth(gregorianDate);
        }
    }
}

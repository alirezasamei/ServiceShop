using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace App.EndPoint.Mvc.UI.Utilities
{
    public static class EnumExtensions
    {
        public static string? GetDisplayName(this Enum enumValue) =>
             enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
    }
}

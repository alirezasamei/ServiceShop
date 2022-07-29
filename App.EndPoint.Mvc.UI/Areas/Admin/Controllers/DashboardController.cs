using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoint.Mvc.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserName = this.User.FindFirstValue(ClaimTypes.Name);
            return View();
        }
    }
}

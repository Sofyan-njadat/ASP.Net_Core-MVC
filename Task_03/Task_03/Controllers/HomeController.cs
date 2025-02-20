using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task_03.Models;

namespace Task_03.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("IsLoggedIn") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
    }
}

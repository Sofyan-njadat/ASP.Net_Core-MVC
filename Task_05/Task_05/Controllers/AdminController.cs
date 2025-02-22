using Microsoft.AspNetCore.Mvc;

namespace Task_05.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}

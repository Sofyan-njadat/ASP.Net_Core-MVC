using Microsoft.AspNetCore.Mvc;

namespace Task_02.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

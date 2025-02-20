using Microsoft.AspNetCore.Mvc;

namespace Task_04.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

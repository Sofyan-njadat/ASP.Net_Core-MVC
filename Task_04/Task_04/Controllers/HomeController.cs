using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task_04.Models;

namespace Task_04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Calculate(string Num1, string Num2, string Opera)
        {
            int Result = 0;
            if (Opera == "+")
            {
                Result = Convert.ToInt32(Num1) + Convert.ToInt32(Num2);
            }
            else if (Opera == "-")
            {
                Result = Convert.ToInt32(Num1) - Convert.ToInt32(Num2);
            }
            else if (Opera == "")
            {
                Result = Convert.ToInt32(Num1) * Convert.ToInt32(Num2);
            }
            else if (Opera == "/")
            {
                Result = Convert.ToInt32(Num1) / Convert.ToInt32(Num2);
            }
            else
            {
                Result = 0;
            }

            TempData["Res"] = Result;

            return RedirectToAction("Index");


        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SetCookie()
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(5) // تنتهي بعد 5 دقائق
            };
            Response.Cookies.Append("User", "Ahmed", options); /// options--> يحتوي على إعدادات مثل مدة صلاحية الكوكي
            return Content("Cookies Saved ");
        }


        public IActionResult GetCookie()
        {
            string user = Request.Cookies["User"] ?? "Unavailable";
            return Content($"The Saved Cookies is: {user}");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }
}

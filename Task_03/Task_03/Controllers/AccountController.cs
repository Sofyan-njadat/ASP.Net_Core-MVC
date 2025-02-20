using Microsoft.AspNetCore.Mvc;

namespace Task_03.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string Username, string Email, string Password, string ConfirmPassword)
        {
            if (Password != ConfirmPassword)
            {
                ViewBag.Error = "Enter Match Password !";
                return View();
            }

            // تخزين الداتا بالسيشن 
            HttpContext.Session.SetString("Username", Username);
            HttpContext.Session.SetString("Email", Email);
            HttpContext.Session.SetString("Password", Password);

            return RedirectToAction("Login"); // توجيه لصفحة اللوج إن بعد ما يسجل معلوماته
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            // ترجيع الداتا من السيشن
            string storedEmail = HttpContext.Session.GetString("Email");
            string storedPassword = HttpContext.Session.GetString("Password");

            if (Email == storedEmail && Password == storedPassword)
            {
                HttpContext.Session.SetString("IsLoggedIn", "true");
                return RedirectToAction("Index", "Home"); // توجيه للهوم
            }

            ViewBag.Error = "Correct Your Email Or Password !";
            return View();
        }

        public IActionResult Profile()
        {
            if (HttpContext.Session.GetString("IsLoggedIn") == "true")
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                ViewBag.Email = HttpContext.Session.GetString("Email");
                ViewBag.Password = HttpContext.Session.GetString("Password");
                return View();
            }
            return RedirectToAction("Login"); // اذا مش عامل Login يرجعه عالتسجيل 
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // حذف جميع بيانات الجلسة
            return RedirectToAction("Login"); // إعادة التوجيه لصفحة تسجيل الدخول
        }
    }
}

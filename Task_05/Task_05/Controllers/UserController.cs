using Microsoft.AspNetCore.Mvc;

namespace Task_05.Controllers
{
    public class UserController : Controller
    {
        string sessionName = "user_name";
        string sessionPass = "password";
        string sessionEmail = "email";
        public IActionResult Regestration()
        {
            return View();
        }
        public IActionResult HandleRegestration(string name, string email, string password, string rptpassword)
        {
            if (password != rptpassword)
            {
                TempData["ErrorPass"] = "Your Password Dosen't Match !";
                return RedirectToAction("Regestration");
            }
            else
            {
                TempData["Email"] = email;
                TempData["Pass"] = password;
                TempData["Name"] = name;
                return RedirectToAction("Login");
            }
        }


        public IActionResult Login()
        {
            string UserData = Request.Cookies["userInfo"];
            if (UserData != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult HandleLogin(string email, string password, string remmber)
        {
            if (TempData["Email"] == null)
            {
                TempData["ErrorMsg"] = "Create an Account Before Login !";
                return RedirectToAction("Login");
            }

            HttpContext.Session.SetString(sessionEmail, TempData["Email"].ToString());
            HttpContext.Session.SetString(sessionPass, TempData["Pass"].ToString());
            HttpContext.Session.SetString(sessionName, TempData["Name"].ToString());

            string Email = HttpContext.Session.GetString(sessionEmail);
            string Pass = HttpContext.Session.GetString(sessionPass);

            if (email == Email && Pass == password)
            {
                if (remmber != null)
                {
                    CookieOptions SavingTime = new CookieOptions();
                    SavingTime.Expires = DateTime.Now.AddDays(30);
                    HttpContext.Response.Cookies.Append("userInfo", TempData["Email"].ToString(), SavingTime);
                    HttpContext.Response.Cookies.Append("userName", TempData["Name"].ToString(), SavingTime);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMsg"] = "Invalid Email Or Password !";
                return RedirectToAction("Login");
            }
        }

        public IActionResult Profile()
        {
            // جلب البيانات من الـ Session أو Cookies
            string username = HttpContext.Session.GetString(sessionName) ?? HttpContext.Request.Cookies["userName"] ?? "";
            string email = HttpContext.Session.GetString(sessionEmail) ?? HttpContext.Request.Cookies["userInfo"] ?? "";
            string phone = HttpContext.Session.GetString("phone") ?? "";
            string address = HttpContext.Session.GetString("address") ?? "";

            // تمرير البيانات إلى الـ View
            ViewBag.Username = username;
            ViewBag.Email = email;
            ViewBag.Phone = phone;
            ViewBag.Address = address;

            return View();
        }

        [HttpPost]
        public IActionResult EditProfile(string username, string email, string phone, string address)
        {
            // حفظ البيانات في الجلسة (Session)
            HttpContext.Session.SetString(sessionName, username);
            HttpContext.Session.SetString(sessionEmail, email);
            HttpContext.Session.SetString("phone", phone);
            HttpContext.Session.SetString("address", address);

            // حفظ البيانات في الكوكيز (Cookies)
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("userName", username, options);
            Response.Cookies.Append("userInfo", email, options);

            // إعادة توجيه المستخدم إلى صفحة البروفايل
            return RedirectToAction("Profile");
        }
    

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("userInfo");
            return RedirectToAction("Index", "Home");
        }

    }
}

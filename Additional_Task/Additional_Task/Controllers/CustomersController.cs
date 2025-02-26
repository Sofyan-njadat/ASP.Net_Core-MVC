using Additional_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Additional_Task.Controllers
{
    
    
    public class CustomersController : Controller
    {
        private readonly MyDbContext DB;

        public CustomersController(MyDbContext db)
        {
            DB = db;
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View("Register");
        }
        // POST: CustomersController/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                DB.Customers.Add(customer);
                DB.SaveChanges();
                return RedirectToAction("Login");
            }
            catch
            {
                return View("Register");
            }
        }





        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var customer = DB.Customers.FirstOrDefault(c => c.Email == email && c.Password == password);
            if (customer != null)
            {
                // تخزين اسم المستخدم في Session أو ViewBag
                HttpContext.Session.SetString("UserName", customer.Name);
                //ViewBag.UserName = customer.Name;
                
                return RedirectToAction("Home");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Home()
        {
            var userName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = userName;
            return View();
        }







        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_07.Models;

namespace Task_07.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
                return RedirectToAction("Login", "Account");

            return View();
        }
        public async Task<IActionResult> Users()
        {
            return View(await _context.AllUsers.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allUser = await _context.AllUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allUser == null)
            {
                return NotFound();
            }

            return View(allUser);
        }

        //GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Role")] AllUser allUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Users));
            }
            return View(allUser);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allUser = await _context.AllUsers.FindAsync(id);
            if (allUser == null)
            {
                return NotFound();
            }
            return View(allUser);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,Role")] AllUser allUser)
        {
            if (id != allUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllUserExists(allUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Users));
            }
            return View(allUser);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allUser = await _context.AllUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allUser == null)
            {
                return NotFound();
            }

            return View(allUser);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allUser = await _context.AllUsers.FindAsync(id);
            if (allUser != null)
            {
                _context.AllUsers.Remove(allUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Users));
        }

        private bool AllUserExists(int id)
        {
            return _context.AllUsers.Any(e => e.Id == id);
        }


        /////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////

        public IActionResult Products()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
                return RedirectToAction("Login", "Account");

            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Products");
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> PEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PEdit(int id, [Bind("Id,ProductName,Description,Price")] Product Products)
        {
            if (id != Products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Update(Products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Product));
            }
            return View(Products);
        }


        // GET: Product/Delete/5
        public async Task<IActionResult> PDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("PDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PDeleteConfirmed(int id)
        {
            var Products = await _context.Products.FindAsync(id);
            if (Products != null)
            {
                _context.Products.Remove(Products);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Products));
        }











    }
}

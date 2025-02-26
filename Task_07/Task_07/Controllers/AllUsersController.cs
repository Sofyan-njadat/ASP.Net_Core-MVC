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
    public class AllUsersController : Controller
    {
        private readonly MyDbContext _context;

        public AllUsersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: AllUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllUsers.ToListAsync());
        }

        // GET: AllUsers/Details/5
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

        // GET: AllUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Role")] AllUser User)
        {
            if (ModelState.IsValid)
            {
                _context.Add(User);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(User);
        }

        // GET: AllUsers/Edit/5
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

        // POST: AllUsers/Edit/5
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
                return RedirectToAction(nameof(Index));
            }
            return View(allUser);
        }

        // GET: AllUsers/Delete/5
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

        // POST: AllUsers/Delete/5
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
            return RedirectToAction(nameof(Index));
        }

        private bool AllUserExists(int id)
        {
            return _context.AllUsers.Any(e => e.Id == id);
        }
    }
}

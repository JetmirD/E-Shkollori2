using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using ASP.NETCoreIdentityCustom.Models;
using Microsoft.AspNetCore.Identity;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class testisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public testisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: testis
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            var userModels = users.Select(user => (testi)user).ToList();
            return View(userModels);
        }

        // GET: testis/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.testi == null)
            {
                return NotFound();
            }

            var testi = await _context.testi
                .FirstOrDefaultAsync(m => m.FirstName == id);
            if (testi == null)
            {
                return NotFound();
            }

            return View(testi);
        }

        // GET: testis/Create
        public async Task<IActionResult> Create()
        {
            var users = await _context.Users.ToListAsync();
            var userModels = users.Select(user => (testi)user).ToList();
            ViewData["Users"] = new SelectList(userModels, "FirstName", "FullName");
            return View();
        }

        // POST: testis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName")] testi testi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testi);
        }

        // GET: testis/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var users = await _context.Users.ToListAsync();
            var userModels = users.Select(user => (testi)user).ToList();
            ViewData["Users"] = new SelectList(userModels, "FirstName", "FullName");
            return View();
        }

        // POST: testis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName")] testi testi)
        {
            if (id != testi.FirstName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!testiExists(testi.FirstName))
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
            return View(testi);
        }

        // GET: testis/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.testi == null)
            {
                return NotFound();
            }

            var testi = await _context.testi
                .FirstOrDefaultAsync(m => m.FirstName == id);
            if (testi == null)
            {
                return NotFound();
            }

            return View(testi);
        }

        // POST: testis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.testi == null)
            {
                return Problem("Entity set 'ApplicationDbContext.testi'  is null.");
            }
            var testi = await _context.testi.FindAsync(id);
            if (testi != null)
            {
                _context.testi.Remove(testi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool testiExists(string id)
        {
          return _context.testi.Any(e => e.FirstName == id);
        }
    }
}

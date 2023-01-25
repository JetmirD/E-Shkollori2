using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using ASP.NETCoreIdentityCustom.Models;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class LendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lenda
        public async Task<IActionResult> Index()
        {
              return View(await _context.Lenda.ToListAsync());
        }

        // GET: Lenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lenda == null)
            {
                return NotFound();
            }

            var lenda = await _context.Lenda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lenda == null)
            {
                return NotFound();
            }

            return View(lenda);
        }

        // GET: Lenda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ECTS")] Lenda lenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lenda);
        }

        // GET: Lenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lenda == null)
            {
                return NotFound();
            }

            var lenda = await _context.Lenda.FindAsync(id);
            if (lenda == null)
            {
                return NotFound();
            }
            return View(lenda);
        }

        // POST: Lenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ECTS")] Lenda lenda)
        {
            if (id != lenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendaExists(lenda.Id))
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
            return View(lenda);
        }

        // GET: Lenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lenda == null)
            {
                return NotFound();
            }

            var lenda = await _context.Lenda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lenda == null)
            {
                return NotFound();
            }

            return View(lenda);
        }

        // POST: Lenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lenda == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lenda'  is null.");
            }
            var lenda = await _context.Lenda.FindAsync(id);
            if (lenda != null)
            {
                _context.Lenda.Remove(lenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendaExists(int id)
        {
          return _context.Lenda.Any(e => e.Id == id);
        }
    }
}

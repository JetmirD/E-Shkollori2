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
    public class ShkollasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShkollasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shkollas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Shkolla.ToListAsync());
        }

        // GET: Shkollas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shkolla == null)
            {
                return NotFound();
            }

            var shkolla = await _context.Shkolla
                .FirstOrDefaultAsync(m => m.ShkollaId == id);
            if (shkolla == null)
            {
                return NotFound();
            }

            return View(shkolla);
        }

        // GET: Shkollas/Create
        public IActionResult Create()
        {
            Shkolla model = new Shkolla();
            return View(model);
        }

        // POST: Shkollas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShkollaId,EmriShkolles,SelectedLlojiShkolles")] Shkolla shkolla)
        {
            if (ModelState.IsValid)
            {
                var selectedLlojiShkolles = Request.Form["SelectedLlojiShkolles"];
                shkolla.SelectedLlojiShkolles = selectedLlojiShkolles;
                _context.Add(shkolla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shkolla);
        }

        // GET: Shkollas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shkolla == null)
            {
                return NotFound();
            }

            var shkolla = await _context.Shkolla.FindAsync(id);
            if (shkolla == null)
            {
                return NotFound();
            }
            return View(shkolla);
        }

        // POST: Shkollas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShkollaId,EmriShkolles,SelectedLlojiShkolles")] Shkolla shkolla)
        {
            var selectedLlojiShkolles = Request.Form["SelectedLlojiShkolles"];
            shkolla.SelectedLlojiShkolles = selectedLlojiShkolles;

            if (id != shkolla.ShkollaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shkolla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShkollaExists(shkolla.ShkollaId))
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
            return View(shkolla);
        }

        // GET: Shkollas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shkolla == null)
            {
                return NotFound();
            }

            var shkolla = await _context.Shkolla
                .FirstOrDefaultAsync(m => m.ShkollaId == id);
            if (shkolla == null)
            {
                return NotFound();
            }

            return View(shkolla);
        }

        // POST: Shkollas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shkolla == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Shkolla'  is null.");
            }
            var shkolla = await _context.Shkolla.FindAsync(id);
            if (shkolla != null)
            {
                _context.Shkolla.Remove(shkolla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShkollaExists(int id)
        {
          return _context.Shkolla.Any(e => e.ShkollaId == id);
        }
    }
}

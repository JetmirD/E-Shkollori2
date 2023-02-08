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
    public class OrarisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrarisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Oraris
        public async Task<IActionResult> Index(
     string sortOrder,
     string currentFilter,
     string searchString,
     int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var orari = from s in _context.Orari
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                orari = orari.Where(s => 
                                       s.Lenda.EmriLendes.Contains(searchString));
            }
            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        orari = orari.OrderByDescending(s => s.LastName);
            //        break;
            //    case "Date":
            //        orari = orari.OrderBy(s => s.EnrollmentDate);
            //        break;
            //    case "date_desc":
            //        students = students.OrderByDescending(s => s.EnrollmentDate);
            //        break;
            //    default:
            //        students = students.OrderBy(s => s.LastName);
            //        break;
            //}

            int pageSize = 3;
            return View(await PaginatedList<Orari>.CreateAsync(orari.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Oraris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orari == null)
            {
                return NotFound();
            }

            var orari = await _context.Orari
                .Include(o => o.Lenda)
                .FirstOrDefaultAsync(m => m.OrariId == id);
            if (orari == null)
            {
                return NotFound();
            }

            return View(orari);
        }

        // GET: Oraris/Create
        public IActionResult Create()
        {
            ViewData["LendaId"] = new SelectList(_context.Lenda2, "LendaId", "EmriLendes");
            return View();
        }

        // POST: Oraris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrariId,LendaId,Koha,Klasa")] Orari orari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LendaId"] = new SelectList(_context.Lenda2, "LendaId", "EmriLendes", orari.LendaId);
            return View(orari);
        }

        // GET: Oraris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orari == null)
            {
                return NotFound();
            }

            var orari = await _context.Orari.FindAsync(id);
            if (orari == null)
            {
                return NotFound();
            }
            ViewData["LendaId"] = new SelectList(_context.Lenda2, "LendaId", "EmriLendes", orari.LendaId);
            return View(orari);
        }

        // POST: Oraris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrariId,LendaId,Koha,Klasa")] Orari orari)
        {
            if (id != orari.OrariId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrariExists(orari.OrariId))
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
            ViewData["LendaId"] = new SelectList(_context.Lenda2, "LendaId", "EmriLendes", orari.LendaId);
            return View(orari);
        }

        // GET: Oraris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orari == null)
            {
                return NotFound();
            }

            var orari = await _context.Orari
                .Include(o => o.Lenda)
                .FirstOrDefaultAsync(m => m.OrariId == id);
            if (orari == null)
            {
                return NotFound();
            }

            return View(orari);
        }

        // POST: Oraris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orari == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orari'  is null.");
            }
            var orari = await _context.Orari.FindAsync(id);
            if (orari != null)
            {
                _context.Orari.Remove(orari);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrariExists(int id)
        {
            return _context.Orari.Any(e => e.OrariId == id);
        }
    }
}
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
    public class NxenesisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NxenesisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nxenesis
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desci" : "";
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

            var nxenesi = from n in _context.Nxenesi.Include(o=>o.Shkolla)
                          select n;
            if (!String.IsNullOrEmpty(searchString))
            {
                nxenesi = nxenesi.Where(n => n.Emri.Contains(searchString)
                                       || n.Mbiemri.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    nxenesi = nxenesi.OrderByDescending(n => n.Emri);
                    break;
                case "name_desci":
                    nxenesi = nxenesi.OrderByDescending(n => n.Mbiemri);
                    break;
                default:
                    nxenesi = nxenesi.OrderBy(n => n.Shkolla);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Nxenesi>.CreateAsync(nxenesi.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Nxenesis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nxenesi == null)
            {
                return NotFound();
            }

            var nxenesi = await _context.Nxenesi
                .Include(n => n.Shkolla)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nxenesi == null)
            {
                return NotFound();
            }

            return View(nxenesi);
        }

        // GET: Nxenesis/Create
        public IActionResult Create()
        {
            ViewData["ShkollaId"] = new SelectList(_context.Shkolla, "ShkollaId", "EmriShkolles");
            return View();
        }

        // POST: Nxenesis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Emri,Mbiemri,DataLindjes,NumriTelefonit,ShkollaId")] Nxenesi nxenesi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nxenesi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShkollaId"] = new SelectList(_context.Shkolla, "ShkollaId", "EmriShkolles", nxenesi.ShkollaId);
            return View(nxenesi);
        }

        // GET: Nxenesis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nxenesi == null)
            {
                return NotFound();
            }

            var nxenesi = await _context.Nxenesi.FindAsync(id);
            if (nxenesi == null)
            {
                return NotFound();
            }
            ViewData["ShkollaId"] = new SelectList(_context.Shkolla, "ShkollaId", "EmriShkolles", nxenesi.ShkollaId);
            return View(nxenesi);
        }

        // POST: Nxenesis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Emri,Mbiemri,DataLindjes,NumriTelefonit,ShkollaId")] Nxenesi nxenesi)
        {
            if (id != nxenesi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nxenesi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NxenesiExists(nxenesi.Id))
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
            ViewData["ShkollaId"] = new SelectList(_context.Shkolla, "ShkollaId", "EmriShkolles", nxenesi.ShkollaId);
            return View(nxenesi);
        }

        // GET: Nxenesis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nxenesi == null)
            {
                return NotFound();
            }

            var nxenesi = await _context.Nxenesi
                .Include(n => n.Shkolla)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nxenesi == null)
            {
                return NotFound();
            }

            return View(nxenesi);
        }

        // POST: Nxenesis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nxenesi == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nxenesi'  is null.");
            }
            var nxenesi = await _context.Nxenesi.FindAsync(id);
            if (nxenesi != null)
            {
                _context.Nxenesi.Remove(nxenesi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NxenesiExists(int id)
        {
          return _context.Nxenesi.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using ASP.NETCoreIdentityCustom.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NETCoreIdentityCustom.Controllers
{
   
    public class Lenda2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Lenda2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lenda2
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            //Kodi per Sortimin Ascending te Crudit
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
            ViewData["NameSortParm1"] = String.IsNullOrEmpty(sortOrder) ? "name_asc1" : "";
            //Kodi per filtrimin e Crudit
            ViewData["CurrentFilter"] = searchString;
            //kodi per pagination
            ViewData["CurrentSort"] = sortOrder;


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;


            var lendet = from s in _context.Lenda2
                           select s;

            //Kodi per filtrimin e Crudit
            if (!String.IsNullOrEmpty(searchString))
            {
                lendet = lendet.Where(s => s.EmriLendes.Contains(searchString));
            }
            //Kodi per Sortimin Ascending te Crudit
            switch (sortOrder)
            {
                case "name_asc":
                    lendet = lendet.OrderBy(s => s.EmriLendes);
                    break;
                case "name_asc1":
                   lendet = lendet.OrderBy(s => s.SelectedLlojiLendes);
                    break;
              
            }

            int pageSize = 3;
            return View(await PaginatedList<Lenda2>.CreateAsync(lendet.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Lenda2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lenda2 == null)
            {
                return NotFound();
            }

            var lenda2 = await _context.Lenda2
                .FirstOrDefaultAsync(m => m.LendaId == id);
            if (lenda2 == null)
            {
                return NotFound();
            }

            return View(lenda2);
        }

        // GET: Lenda2/Create
        public IActionResult Create()
        {
            Lenda2 model = new Lenda2();
            return View(model);
        }

        // POST: Lenda2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LendaId,EmriLendes, SelectedLlojiLendes")] Lenda2 lenda2)
        {
            if (ModelState.IsValid)
            {
                //Kjo e ben Request.Form Selected llojin e lendes per me marr llojin specifik per cdo lende qe shtohet
                var selectedLlojiLendes = Request.Form["SelectedLlojiLendes"];
                lenda2.SelectedLlojiLendes = selectedLlojiLendes; 
                _context.Add(lenda2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lenda2);
        }

        // GET: Lenda2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            if (id == null || _context.Lenda2 == null)
            {
                return NotFound();
            }

            var lenda2 = await _context.Lenda2.FindAsync(id);
            if (lenda2 == null)
            {
                return NotFound();
            }
            return View(lenda2);
        }

        // POST: Lenda2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LendaId,EmriLendes")] Lenda2 lenda2)
        {
            //Kjo e ben Request.Form Selected llojin e lendes per me marr llojin specifik per cdo lende qe shtohet
            var selectedLlojiLendes = Request.Form["SelectedLlojiLendes"];
            lenda2.SelectedLlojiLendes = selectedLlojiLendes;
            if (id != lenda2.LendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lenda2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Lenda2Exists(lenda2.LendaId))
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
            return View(lenda2);
        }

        // GET: Lenda2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lenda2 == null)
            {
                return NotFound();
            }

            var lenda2 = await _context.Lenda2
                .FirstOrDefaultAsync(m => m.LendaId == id);
            if (lenda2 == null)
            {
                return NotFound();
            }

            return View(lenda2);
        }

        // POST: Lenda2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lenda2 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lenda2'  is null.");
            }
            var lenda2 = await _context.Lenda2.FindAsync(id);
            if (lenda2 != null)
            {
                _context.Lenda2.Remove(lenda2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Lenda2Exists(int id)
        {
          return _context.Lenda2.Any(e => e.LendaId == id);
        }
    }
}

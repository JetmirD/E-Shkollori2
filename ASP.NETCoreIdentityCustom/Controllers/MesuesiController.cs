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
    public class MesuesiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MesuesiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mesuesi
        public async Task<IActionResult> Index(int pg = 1)
        {
//              return View(await _context.Mesuesi.ToListAsync());


            List<Mesuesi> mesues = _context.Mesuesi.ToList();

            //KOD PER PAGER
            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = mesues.Count();
            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = mesues.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            //return View(await _context.Students.ToListAsync());
            return View(data);

            //    return View(await _context.Studenti.ToListAsync());
        }

        // GET: Mesuesi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mesuesi == null)
            {
                return NotFound();
            }

            var mesuesi = await _context.Mesuesi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mesuesi == null)
            {
                return NotFound();
            }

            return View(mesuesi);
        }

        // GET: Mesuesi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mesuesi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email,Lenda")] Mesuesi mesuesi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesuesi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mesuesi);
        }

        // GET: Mesuesi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mesuesi == null)
            {
                return NotFound();
            }

            var mesuesi = await _context.Mesuesi.FindAsync(id);
            if (mesuesi == null)
            {
                return NotFound();
            }
            return View(mesuesi);
        }

        // POST: Mesuesi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Email,Lenda")] Mesuesi mesuesi)
        {
            if (id != mesuesi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesuesi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesuesiExists(mesuesi.Id))
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
            return View(mesuesi);
        }

        // GET: Mesuesi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mesuesi == null)
            {
                return NotFound();
            }

            var mesuesi = await _context.Mesuesi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mesuesi == null)
            {
                return NotFound();
            }

            return View(mesuesi);
        }

        // POST: Mesuesi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mesuesi == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mesuesi'  is null.");
            }
            var mesuesi = await _context.Mesuesi.FindAsync(id);
            if (mesuesi != null)
            {
                _context.Mesuesi.Remove(mesuesi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesuesiExists(int id)
        {
          return _context.Mesuesi.Any(e => e.Id == id);
        }
    }
}

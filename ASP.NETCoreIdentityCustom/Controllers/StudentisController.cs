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
    [Authorize]
    public class StudentisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Studentis
        public async Task<IActionResult> Index(int pg=1)
        {
            List<Studenti> student = _context.Studenti.ToList();


            //KOD PER PAGER
            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = student.Count();
            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = student.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            //return View(await _context.Students.ToListAsync());
            return View(data);

        //    return View(await _context.Studenti.ToListAsync());
        }

        // GET: Studentis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Studenti == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studenti == null)
            {
                return NotFound();
            }

            return View(studenti);
        }

        // GET: Studentis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studentis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email")] Studenti studenti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studenti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studenti);
        }

        // GET: Studentis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Studenti == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti.FindAsync(id);
            if (studenti == null)
            {
                return NotFound();
            }
            return View(studenti);
        }

        // POST: Studentis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Email")] Studenti studenti)
        {
            if (id != studenti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studenti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentiExists(studenti.Id))
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
            return View(studenti);
        }

        // GET: Studentis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Studenti == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studenti == null)
            {
                return NotFound();
            }

            return View(studenti);
        }

        // POST: Studentis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Studenti == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Studenti'  is null.");
            }
            var studenti = await _context.Studenti.FindAsync(id);
            if (studenti != null)
            {
                _context.Studenti.Remove(studenti);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentiExists(int id)
        {
          return _context.Studenti.Any(e => e.Id == id);
        }
    }
}

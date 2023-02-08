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
using static ASP.NETCoreIdentityCustom.Core.Constants;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class Transkripta2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Transkripta2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transkripta2
        public async Task<IActionResult> Index()
        {
            //        var applicationDbContext = _context.Transkripta2
            //                                     .Include(t => t.Lenda);

            //return View(await applicationDbContext.ToListAsync());
            var transkripta = await _context.Transkripta2
                .Include(t => t.Lenda)
                .Select(t => new Transkripta2
                {
                    TranskriptaId = t.TranskriptaId,
                    Nota = t.Nota,
                    CreatedAt = t.CreatedAt,
                    Lenda = t.Lenda,
                    FirstName = t.FirstName
                })
                .ToListAsync();


            return View(transkripta);


        }

        // GET: Transkripta2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transkripta2 == null)
            {
                return NotFound();
            }

            var transkripta2 = await _context.Transkripta2
                .Include(t => t.Lenda)
                .FirstOrDefaultAsync(m => m.TranskriptaId == id);
            if (transkripta2 == null)
            {
                return NotFound();
            }

            return View(transkripta2);
        }

        // GET: Transkripta2/Create
        public async Task<IActionResult> Create()
        {
            ////Ky kod sherben per mi shfaq te gjithe useret me ni liste
            //var users = await _context.Users.ToListAsync();
            //var userModels = users.Select(user => (Transkripta2)user).ToList();
            //ViewData["Users"] = new SelectList(userModels, "FirstName", "FullName");



            //ViewData["LendaId"] = new SelectList(_context.Lenda2, "LendaId", "EmriLendes");
            //return View();

            var users = await _context.Users.ToListAsync();
            ViewData["Users"] = new SelectList(users, "FirstName", "FullName");
            ViewData["LendaId"] = new SelectList(_context.Lenda2, "LendaId", "EmriLendes");
            return View();


        }

        // POST: Transkripta2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TranskriptaId,Nota,CreatedAt,LendaId,FirstName,LastName")] Transkripta2 transkripta2)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(transkripta2);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["LendaId"] = new SelectList(_context.Lenda2, "LendaId", "EmriLendes", transkripta2.LendaId);
            //return View(transkripta2);

            if (ModelState.IsValid)
            {
                _context.Add(transkripta2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LendaId"] = new SelectList(_context.Lenda2, "LendaId", "EmriLendes", transkripta2.LendaId);
            return View(transkripta2);

        }

        // GET: Transkripta2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transkripta2 == null)
            {
                return NotFound();
            }

            var transkripta2 = await _context.Transkripta2.FindAsync(id);
            if (transkripta2 == null)
            {
                return NotFound();
            }
            ViewData["LendaId"] = new SelectList(_context.Lenda2, "LendaId", "EmriLendes", transkripta2.LendaId);
            return View(transkripta2);
        }

        // POST: Transkripta2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TranskriptaId,Nota,CreatedAt,LendaId,FirstName,LastName")] Transkripta2 transkripta2)
        {
            if (id != transkripta2.TranskriptaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transkripta2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Transkripta2Exists(transkripta2.TranskriptaId))
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
            ViewData["LendaId"] = new SelectList(_context.Lenda2, "LendaId", "EmriLendes", transkripta2.LendaId);
            return View(transkripta2);
        }

        // GET: Transkripta2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transkripta2 == null)
            {
                return NotFound();
            }

            var transkripta2 = await _context.Transkripta2
                .Include(t => t.Lenda)
                .FirstOrDefaultAsync(m => m.TranskriptaId == id);
            if (transkripta2 == null)
            {
                return NotFound();
            }

            return View(transkripta2);
        }

        // POST: Transkripta2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transkripta2 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transkripta2'  is null.");
            }
            var transkripta2 = await _context.Transkripta2.FindAsync(id);
            if (transkripta2 != null)
            {
                _context.Transkripta2.Remove(transkripta2);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Transkripta2Exists(int id)
        {
            return _context.Transkripta2.Any(e => e.TranskriptaId == id);
        }
    }
}
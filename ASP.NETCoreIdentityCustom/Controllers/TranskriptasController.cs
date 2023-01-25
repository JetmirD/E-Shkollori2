using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using ASP.NETCoreIdentityCustom.Models;
using ASP.NETCoreIdentityCustom.Core.ViewModels;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class TranskriptasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationUser __context;
        public TranskriptasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transkriptas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transkripta.ToListAsync());
        }

        // GET: Transkriptas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transkripta = await _context.Transkripta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transkripta == null)
            {
                return NotFound();
            }

            return View(transkripta);
        }

        // GET: Transkriptas/Create
        public IActionResult Create()
        {

            //var users = _context.Users.ToList();
            //var userSelectList = new SelectList(users, "Emri", "Mbiemri", null);


            //ViewBag.UserSelectList = userSelectList;
            //return View();

            ////listo te gjitha lendet
            //List<Lenda> lendet = this._context.Lenda.ToList();
            //VleresimiViewModel model = new VleresimiViewModel();

            ////model.Studentet = studentet;
            //model.Lendet = lendet;

            
            //return View(model);



            var users = _context.Users.ToList();
            var userSelectList = new SelectList(users, "Emri", "Mbiemri", null);

            List<Lenda> lendet = this._context.Lenda.ToList();
            VleresimiViewModel model = new VleresimiViewModel();
            model.UserSelectList = userSelectList;
            model.Lendet = lendet;
            return View(model);
        }

        private ApplicationUser GetApplicationUser()
        {
            throw new NotImplementedException();
        }

        // POST: Transkriptas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VleresimiViewModel model)   
        {
            //using (var context = new ApplicationDbContext())
            //{
            //    var studentet = context.Users.ToList();
            //    var viewModel = new VleresimiViewModel
            //    {
            //        Studentet = studentet
            //    };
            //    return View(viewModel);
            //}

            var student = this._context.Users.Find(model.StudentId);
            var lenda = this._context.Lenda.Find(model.LendaId);

            var transkripta = new Transkripta();
            //transkripta.Lenda = lenda;
            //transkripta.ApplicationUser = student;
            transkripta.Nota = (int)model.Nota;

            this._context.Transkripta.Add(transkripta);
            this._context.SaveChanges();



            //if (ModelState.IsValid)
            //{
            //    _context.Add(transkripta);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return View();
        }

        // GET: Transkriptas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transkripta = await _context.Transkripta.FindAsync(id);
            if (transkripta == null)
            {
                return NotFound();
            }
            return View(transkripta);
        }

        // POST: Transkriptas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nota")] Transkripta transkripta)
        {
            if (id != transkripta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transkripta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranskriptaExists(transkripta.Id))
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
            return View(transkripta);
        }

        // GET: Transkriptas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transkripta = await _context.Transkripta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transkripta == null)
            {
                return NotFound();
            }

            return View(transkripta);
        }

        // POST: Transkriptas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transkripta = await _context.Transkripta.FindAsync(id);
            _context.Transkripta.Remove(transkripta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranskriptaExists(int id)
        {
            return _context.Transkripta.Any(e => e.Id == id);
        }
    }
}

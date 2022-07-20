using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkersCompany.Context;
using WorkersCompany.Models;

namespace WorkersCompany.Controllers
{
    public class CargaFamiliarController : Controller
    {
        private readonly YuriDBContext _context;

        public CargaFamiliarController(YuriDBContext context)
        {
            _context = context;
        }

        // GET: CargaFamiliar
        public async Task<IActionResult> Index()
        {
            return View(await _context.CargaFamiliars.ToListAsync());
        }

        // GET: CargaFamiliar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargaFamiliar = await _context.CargaFamiliars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargaFamiliar == null)
            {
                return NotFound();
            }

            return View(cargaFamiliar);
        }

        // GET: CargaFamiliar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CargaFamiliar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Parentesco,Sexo,Rut")] CargaFamiliar cargaFamiliar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargaFamiliar);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Create", "ContactosEmerg");
            }
            return View(cargaFamiliar);
        }

        // GET: CargaFamiliar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargaFamiliar = await _context.CargaFamiliars.FindAsync(id);
            if (cargaFamiliar == null)
            {
                return NotFound();
            }
            return View(cargaFamiliar);
        }

        // POST: CargaFamiliar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Parentesco,Sexo,Rut")] CargaFamiliar cargaFamiliar)
        {
            if (id != cargaFamiliar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargaFamiliar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargaFamiliarExists(cargaFamiliar.Id))
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
            return View(cargaFamiliar);
        }

        // GET: CargaFamiliar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargaFamiliar = await _context.CargaFamiliars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargaFamiliar == null)
            {
                return NotFound();
            }

            return View(cargaFamiliar);
        }

        // POST: CargaFamiliar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargaFamiliar = await _context.CargaFamiliars.FindAsync(id);
            _context.CargaFamiliars.Remove(cargaFamiliar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargaFamiliarExists(int id)
        {
            return _context.CargaFamiliars.Any(e => e.Id == id);
        }
    }
}

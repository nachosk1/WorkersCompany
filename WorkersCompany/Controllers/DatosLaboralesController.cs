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
    public class DatosLaboralesController : Controller
    {
        private readonly YuriDBContext _context;

        public DatosLaboralesController(YuriDBContext context)
        {
            _context = context;
        }

        // GET: DatosLaborales
        public async Task<IActionResult> Index()
        {
            return View(await _context.DatosLaborales.ToListAsync());
        }

        // GET: DatosLaborales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosLaborales = await _context.DatosLaborales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosLaborales == null)
            {
                return NotFound();
            }

            return View(datosLaborales);
        }

        // GET: DatosLaborales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatosLaborales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cargo,FechaIngreso,AreaDepartamento")] DatosLaborales datosLaborales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datosLaborales);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("PasoFinal", "Trabajador");
            }
            return View(datosLaborales);
        }

        // GET: DatosLaborales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosLaborales = await _context.DatosLaborales.FindAsync(id);
            if (datosLaborales == null)
            {
                return NotFound();
            }
            return View(datosLaborales);
        }

        // POST: DatosLaborales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cargo,FechaIngreso,AreaDepartamento")] DatosLaborales datosLaborales)
        {
            if (id != datosLaborales.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datosLaborales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosLaboralesExists(datosLaborales.Id))
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
            return View(datosLaborales);
        }

        // GET: DatosLaborales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosLaborales = await _context.DatosLaborales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosLaborales == null)
            {
                return NotFound();
            }

            return View(datosLaborales);
        }

        // POST: DatosLaborales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datosLaborales = await _context.DatosLaborales.FindAsync(id);
            _context.DatosLaborales.Remove(datosLaborales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosLaboralesExists(int id)
        {
            return _context.DatosLaborales.Any(e => e.Id == id);
        }
    }
}

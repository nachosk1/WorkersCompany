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
    public class TrabajadorController : Controller
    {
        private readonly YuriDBContext _context;

        public TrabajadorController(YuriDBContext context)
        {
            _context = context;
        }
        public async Task<JsonResult> Buscar(string buscar)
        {
            var trabajadorsBuscar = from pepe in _context.Trabajadors select pepe;

            if (!String.IsNullOrEmpty(buscar))
            {
                trabajadorsBuscar = trabajadorsBuscar.Include(t => t.DatosLaborales).Where(t => t.DatosLaborales.AreaDepartamento.Contains(buscar) || t.Nombre.Contains(buscar) || t.Rut.Contains(buscar) || t.Cargo.Contains(buscar));
            }
            var trabajadors = await _context.Trabajadors
                .Include(t => t.ContactosEmerg)
                .ToListAsync();
            var trabajadors2 = await _context.Trabajadors
                .Include(t => t.DatosLaborales)
                .ToListAsync();
            var trabajadors3 = await _context.Trabajadors
                .Include(t => t.CargaFamiliar)
                .ToListAsync();
            return Json(Ok(trabajadorsBuscar));
        }

        // GET: Trabajador
        public async Task<IActionResult> Index()
        {
            var trabajadors = await _context.Trabajadors
                .Include(t => t.ContactosEmerg)
                .ToListAsync();
            var trabajadors2 = await _context.Trabajadors
                .Include(t => t.DatosLaborales)
                .ToListAsync();
            var trabajadors3 = await _context.Trabajadors
                .Include(t => t.CargaFamiliar)
                .ToListAsync();
            return View(trabajadors);
            /*return View(await _context.Trabajadors.ToListAsync());*/
        }

        // GET: Trabajador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajador = await _context.Trabajadors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return View(trabajador);
        }

        // GET: Trabajador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trabajador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Rut,Sexo,Cargo")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trabajador);
        }

        // GET: Trabajador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajador = await _context.Trabajadors.FindAsync(id);
            if (trabajador == null)
            {
                return NotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Rut,Sexo,Cargo")] Trabajador trabajador)
        {
            if (id != trabajador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajadorExists(trabajador.Id))
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
            return View(trabajador);
        }

        // GET: Trabajador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajador = await _context.Trabajadors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return View(trabajador);
        }

        // POST: Trabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabajador = await _context.Trabajadors.FindAsync(id);
            _context.Trabajadors.Remove(trabajador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabajadorExists(int id)
        {
            return _context.Trabajadors.Any(e => e.Id == id);
        }
    }
}

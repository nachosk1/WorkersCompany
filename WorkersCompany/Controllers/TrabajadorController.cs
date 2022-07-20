using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkersCompany.Context;
using WorkersCompany.Filtros;
using WorkersCompany.Models;

namespace WorkersCompany.Controllers
{
    [FiltroSeguridad]
    public class TrabajadorController : Controller
    {
        private readonly YuriDBContext _context;

        public TrabajadorController(YuriDBContext context)
        {
            _context = context;
        }

        // GET: Trabajador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trabajadors.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Nombre,Rut,Sexo,Estado")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "CargaFamiliar");
               // return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Rut,Sexo,Estado")] Trabajador trabajador)
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

        public async Task<IActionResult> PasoFinalAsync()
        {


            var Carga = _context.CargaFamiliars
               .OrderByDescending(c => c.Id)
               .Take(1)
               .FirstOrDefault();

            var Datos = _context.DatosLaborales
               .OrderByDescending(d => d.Id)
                .Take(1)
               .FirstOrDefault();

            var Contact = _context.ContactosEmergs
               .OrderByDescending(t => t.Id)
               .Take(1)
               .FirstOrDefault();

            var Tra = _context.Trabajadors
               .OrderByDescending(t => t.Id)
               .Take(1)
               .FirstOrDefault();

            var User = _context.Usuarios
               .OrderByDescending(t => t.Id)
               .Take(1)
               .FirstOrDefault();



            var update = (from u in _context.Trabajadors
                          where u.Id == Tra.Id
                          select u).FirstOrDefault();
            update.CargaFamiliar = Carga;
            update.DatosLaborales = Datos;
            update.ContactosEmerg = Contact;
            _context.SaveChanges();


            var newUser = new Usuario();
            // newUser.Id = User.Id + 1;
            newUser.Username = Tra.Rut;
            newUser.Password = Tra.Nombre;
            newUser.Trabajador = Tra;


            _context.Usuarios.Add(newUser);
            await _context.SaveChangesAsync();




            return RedirectToAction("Index");

        }

    }
}

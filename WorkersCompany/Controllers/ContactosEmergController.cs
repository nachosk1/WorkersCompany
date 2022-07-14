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
    public class ContactosEmergController : Controller
    {
        private readonly YuriDBContext _context;

        public ContactosEmergController(YuriDBContext context)
        {
            _context = context;
        }

        // GET: ContactosEmerg
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactosEmergs.ToListAsync());
        }

        // GET: ContactosEmerg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactosEmerg = await _context.ContactosEmergs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactosEmerg == null)
            {
                return NotFound();
            }

            return View(contactosEmerg);
        }

        // GET: ContactosEmerg/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactosEmerg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Relacion,Numero")] ContactosEmerg contactosEmerg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactosEmerg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactosEmerg);
        }

        // GET: ContactosEmerg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactosEmerg = await _context.ContactosEmergs.FindAsync(id);
            if (contactosEmerg == null)
            {
                return NotFound();
            }
            return View(contactosEmerg);
        }

        // POST: ContactosEmerg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Relacion,Numero")] ContactosEmerg contactosEmerg)
        {
            if (id != contactosEmerg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactosEmerg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactosEmergExists(contactosEmerg.Id))
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
            return View(contactosEmerg);
        }

        // GET: ContactosEmerg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactosEmerg = await _context.ContactosEmergs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactosEmerg == null)
            {
                return NotFound();
            }

            return View(contactosEmerg);
        }

        // POST: ContactosEmerg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactosEmerg = await _context.ContactosEmergs.FindAsync(id);
            _context.ContactosEmergs.Remove(contactosEmerg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactosEmergExists(int id)
        {
            return _context.ContactosEmergs.Any(e => e.Id == id);
        }
    }
}

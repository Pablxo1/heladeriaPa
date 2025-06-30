using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHeladeria.Models;

namespace WebHeladeria.Controllers
{
    public class PresentacionesController : Controller
    {
        private readonly FinalHeladeriaContext _context;

        public PresentacionesController(FinalHeladeriaContext context)
        {
            _context = context;
        }

        // GET: Presentaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Presentacion.ToListAsync());
        }

        // GET: Presentaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presentacion == null)
            {
                return NotFound();
            }

            return View(presentacion);
        }

        // GET: Presentaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Presentaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,UsuarioRegistro,FechaRegistro,Estado")] Presentacion presentacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presentacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presentacion);
        }

        // GET: Presentaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentacion.FindAsync(id);
            if (presentacion == null)
            {
                return NotFound();
            }
            return View(presentacion);
        }

        // POST: Presentaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,UsuarioRegistro,FechaRegistro,Estado")] Presentacion presentacion)
        {
            if (id != presentacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presentacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresentacionExists(presentacion.Id))
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
            return View(presentacion);
        }

        // GET: Presentaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presentacion == null)
            {
                return NotFound();
            }

            return View(presentacion);
        }

        // POST: Presentaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presentacion = await _context.Presentacion.FindAsync(id);
            if (presentacion != null)
            {
                _context.Presentacion.Remove(presentacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresentacionExists(int id)
        {
            return _context.Presentacion.Any(e => e.Id == id);
        }
    }
}

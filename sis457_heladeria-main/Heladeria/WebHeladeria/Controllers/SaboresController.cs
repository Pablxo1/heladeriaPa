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
    public class SaboresController : Controller
    {
        private readonly FinalHeladeriaContext _context;

        public SaboresController(FinalHeladeriaContext context)
        {
            _context = context;
        }

        // GET: Sabores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sabor.ToListAsync());
        }

        // GET: Sabores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sabor = await _context.Sabor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sabor == null)
            {
                return NotFound();
            }

            return View(sabor);
        }

        // GET: Sabores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sabores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,UsuarioRegistro,FechaRegistro,Estado")] Sabor sabor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sabor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sabor);
        }

        // GET: Sabores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sabor = await _context.Sabor.FindAsync(id);
            if (sabor == null)
            {
                return NotFound();
            }
            return View(sabor);
        }

        // POST: Sabores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,UsuarioRegistro,FechaRegistro,Estado")] Sabor sabor)
        {
            if (id != sabor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sabor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaborExists(sabor.Id))
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
            return View(sabor);
        }

        // GET: Sabores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sabor = await _context.Sabor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sabor == null)
            {
                return NotFound();
            }

            return View(sabor);
        }

        // POST: Sabores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sabor = await _context.Sabor.FindAsync(id);
            if (sabor != null)
            {
                _context.Sabor.Remove(sabor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaborExists(int id)
        {
            return _context.Sabor.Any(e => e.Id == id);
        }
    }
}

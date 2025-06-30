using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
                return NotFound();

            var sabor = await _context.Sabor.FirstOrDefaultAsync(m => m.Id == id);
            if (sabor == null)
                return NotFound();

            return View(sabor);
        }

        // GET: Sabores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sabores/Create (Vista normal)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre")] Sabor sabor)
        {
            if (!string.IsNullOrWhiteSpace(sabor.Nombre))
            {
                sabor.UsuarioRegistro = User.Identity?.Name ?? "sistema";
                sabor.FechaRegistro = DateTime.Now;
                sabor.Estado = 1;
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
                return NotFound();

            var sabor = await _context.Sabor.FindAsync(id);
            if (sabor == null)
                return NotFound();

            return View(sabor);
        }

        // POST: Sabores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,UsuarioRegistro,FechaRegistro,Estado")] Sabor sabor)
        {
            if (id != sabor.Id)
                return NotFound();

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
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sabor);
        }

        // GET: Sabores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var sabor = await _context.Sabor.FirstOrDefaultAsync(m => m.Id == id);
            if (sabor == null)
                return NotFound();

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
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SaborExists(int id)
        {
            return _context.Sabor.Any(e => e.Id == id);
        }

        // ------------------- MÉTODOS AJAX PARA MODAL -------------------

        // Listar sabores (AJAX)
        [HttpGet]
        public async Task<JsonResult> Listar()
        {
            var sabores = await _context.Sabor
                .Where(s => s.Estado == 1)
                .Select(s => new { s.Id, s.Nombre })
                .ToListAsync();
            return Json(sabores);
        }

        // Crear sabor (AJAX)
        [HttpPost]
        public async Task<JsonResult> CreateAjax(string Nombre)
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                return Json(new { success = false, mensaje = "El nombre es obligatorio." });

            var existe = await _context.Sabor.AnyAsync(s => s.Nombre.ToLower() == Nombre.ToLower() && s.Estado == 1);
            if (existe)
                return Json(new { success = false, mensaje = "Ya existe un sabor con ese nombre." });

            var sabor = new Sabor
            {
                Nombre = Nombre,
                UsuarioRegistro = User.Identity?.Name ?? "sistema",
                FechaRegistro = DateTime.Now,
                Estado = 1
            };
            _context.Sabor.Add(sabor);
            await _context.SaveChangesAsync();
            return Json(new { success = true, mensaje = "Sabor agregado exitosamente." });
        }

        // Eliminar sabor (AJAX)
        [HttpPost]
        public async Task<JsonResult> Eliminar(int id)
        {
            var sabor = await _context.Sabor.FindAsync(id);
            if (sabor == null)
                return Json(new { success = false, mensaje = "Sabor no encontrado." });

            var enUso = await _context.Productos.AnyAsync(p => p.IdSabor == id && p.Estado == 1);
            if (enUso)
                return Json(new { success = false, mensaje = "Este sabor no puede ser eliminado porque hay productos que lo están usando." });

            _context.Sabor.Remove(sabor);
            await _context.SaveChangesAsync();
            return Json(new { success = true, mensaje = "Sabor eliminado correctamente." });
        }
    }
}
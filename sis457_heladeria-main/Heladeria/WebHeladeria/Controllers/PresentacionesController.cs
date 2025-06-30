using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
                return NotFound();

            var presentacion = await _context.Presentacion.FirstOrDefaultAsync(m => m.Id == id);
            if (presentacion == null)
                return NotFound();

            return View(presentacion);
        }

        // GET: Presentaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Presentaciones/Create (Vista normal)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descripcion")] Presentacion presentacion)
        {
            if (!string.IsNullOrWhiteSpace(presentacion.Descripcion))
            {
                presentacion.UsuarioRegistro = User.Identity?.Name ?? "sistema";
                presentacion.FechaRegistro = DateTime.Now;
                presentacion.Estado = 1;
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
                return NotFound();

            var presentacion = await _context.Presentacion.FindAsync(id);
            if (presentacion == null)
                return NotFound();

            return View(presentacion);
        }

        // POST: Presentaciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,UsuarioRegistro,FechaRegistro,Estado")] Presentacion presentacion)
        {
            if (id != presentacion.Id)
                return NotFound();

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
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(presentacion);
        }

        // GET: Presentaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var presentacion = await _context.Presentacion.FirstOrDefaultAsync(m => m.Id == id);
            if (presentacion == null)
                return NotFound();

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
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PresentacionExists(int id)
        {
            return _context.Presentacion.Any(e => e.Id == id);
        }

        // ------------------- MÉTODOS AJAX PARA MODAL -------------------

        // Listar presentaciones (AJAX)
        [HttpGet]
        public async Task<JsonResult> Listar()
        {
            var presentaciones = await _context.Presentacion
                .Where(p => p.Estado == 1)
                .Select(p => new { p.Id, p.Descripcion })
                .ToListAsync();
            return Json(presentaciones);
        }

        // Crear presentación (AJAX)
        [HttpPost]
        public async Task<JsonResult> CreateAjax(string Descripcion)
        {
            if (string.IsNullOrWhiteSpace(Descripcion))
                return Json(new { success = false, mensaje = "La descripción es obligatoria." });

            var existe = await _context.Presentacion.AnyAsync(p => p.Descripcion.ToLower() == Descripcion.ToLower() && p.Estado == 1);
            if (existe)
                return Json(new { success = false, mensaje = "Ya existe una presentación con esa descripción." });

            var presentacion = new Presentacion
            {
                Descripcion = Descripcion,
                UsuarioRegistro = User.Identity?.Name ?? "sistema",
                FechaRegistro = DateTime.Now,
                Estado = 1
            };
            _context.Presentacion.Add(presentacion);
            await _context.SaveChangesAsync();
            return Json(new { success = true, mensaje = "Presentación agregada exitosamente." });
        }

        // Eliminar presentación (AJAX)
        [HttpPost]
        public async Task<JsonResult> Eliminar(int id)
        {
            var presentacion = await _context.Presentacion.FindAsync(id);
            if (presentacion == null)
                return Json(new { success = false, mensaje = "Presentación no encontrada." });

            var enUso = await _context.Productos.AnyAsync(p => p.IdPresentacion == id && p.Estado == 1);
            if (enUso)
                return Json(new { success = false, mensaje = "Esta presentación no puede ser eliminada porque hay productos que la están usando." });

            _context.Presentacion.Remove(presentacion);
            await _context.SaveChangesAsync();
            return Json(new { success = true, mensaje = "Presentación eliminada correctamente." });
        }
    }
}
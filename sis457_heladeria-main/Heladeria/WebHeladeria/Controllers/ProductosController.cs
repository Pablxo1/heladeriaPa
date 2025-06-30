using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHeladeria.Models;

namespace WebHeladeria.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        private readonly FinalHeladeriaContext _context;

        public ProductosController(FinalHeladeriaContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var productos = _context.Productos
                .Include(p => p.IdPresentacionNavigation)
                .Include(p => p.IdProveedorNavigation)
                .Include(p => p.IdSaborNavigation);
            return View(await productos.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var producto = await _context.Productos
                .Include(p => p.IdPresentacionNavigation)
                .Include(p => p.IdProveedorNavigation)
                .Include(p => p.IdSaborNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["IdPresentacion"] = new SelectList(_context.Presentacion, "Id", "Descripcion");
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "Id", "RazonSocial");
            ViewData["IdSabor"] = new SelectList(_context.Sabor, "Id", "Nombre");
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!string.IsNullOrWhiteSpace(producto.Nombre) &&
                producto.Precio > 0 &&
                producto.IdProveedor.HasValue &&
                producto.IdSabor.HasValue &&
                producto.IdPresentacion.HasValue)
            {
                producto.FechaRegistro = DateTime.Now;
                producto.UsuarioRegistro = User.Identity?.Name ?? string.Empty;
                producto.Estado = 1;

                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPresentacion"] = new SelectList(_context.Presentacion, "Id", "Descripcion", producto.IdPresentacion);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "Id", "RazonSocial", producto.IdProveedor);
            ViewData["IdSabor"] = new SelectList(_context.Sabor, "Id", "Nombre", producto.IdSabor);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return NotFound();

            ViewData["IdPresentacion"] = new SelectList(_context.Presentacion, "Id", "Descripcion", producto.IdPresentacion);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "Id", "RazonSocial", producto.IdProveedor);
            ViewData["IdSabor"] = new SelectList(_context.Sabor, "Id", "Nombre", producto.IdSabor);
            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    producto.UsuarioRegistro = User.Identity?.Name ?? string.Empty;
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = "Producto editado exitosamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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

            ViewData["IdPresentacion"] = new SelectList(_context.Presentacion, "Id", "Descripcion", producto.IdPresentacion);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "Id", "RazonSocial", producto.IdProveedor);
            ViewData["IdSabor"] = new SelectList(_context.Sabor, "Id", "Nombre", producto.IdSabor);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var producto = await _context.Productos
                .Include(p => p.IdPresentacionNavigation)
                .Include(p => p.IdProveedorNavigation)
                .Include(p => p.IdSaborNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                bool tieneVentas = await _context.VentaDetalles.AnyAsync(vd => vd.IdProducto == id);
                if (tieneVentas)
                {
                    TempData["Error"] = "No se puede eliminar el producto porque tiene ventas asociadas.";
                    return RedirectToAction(nameof(Index));
                }

                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
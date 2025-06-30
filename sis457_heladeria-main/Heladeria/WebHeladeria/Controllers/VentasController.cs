using System;
using System.Collections.Generic;
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
    public class VentasController : Controller
    {
        private readonly FinalHeladeriaContext _context;

        public VentasController(FinalHeladeriaContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var ventas = _context.Venta
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdUsuarioNavigation)
                .Include(v => v.IdTipoPagoNavigation);
            return View(await ventas.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var venta = await _context.Venta
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdUsuarioNavigation)
                .Include(v => v.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (venta == null)
                return NotFound();

            var detalles = await _context.VentaDetalles
                .Include(d => d.IdProductoNavigation)
                .Where(d => d.IdVenta == venta.Id)
                .ToListAsync();

            ViewBag.Detalles = detalles;
            ViewBag.Total = detalles.Sum(d => d.Total);

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = _context.Clientes.Where(c => c.Estado == 1).ToList();
            ViewBag.Productos = _context.Productos.Where(p => p.Estado == 1).ToList();
            ViewBag.TipoPagos = _context.TipoPagos.Where(t => t.Estado == 1).ToList();
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,IdTipoPago,MontoTotal,MontoPago,MontoCambio")] Ventum ventum, string DetalleJson)
        {
            if (string.IsNullOrEmpty(DetalleJson))
            {
                ModelState.AddModelError("", "Debe agregar al menos un producto.");
                ViewBag.Clientes = _context.Clientes.Where(c => c.Estado == 1).ToList();
                ViewBag.Productos = _context.Productos.Where(p => p.Estado == 1).ToList();
                ViewBag.TipoPagos = _context.TipoPagos.Where(t => t.Estado == 1).ToList();
                return View(ventum);
            }

            var detalles = System.Text.Json.JsonSerializer.Deserialize<List<VentaDetalleVM>>(DetalleJson);

            if (detalles == null || detalles.Count == 0)
            {
                ModelState.AddModelError("", "Debe agregar al menos un producto.");
                ViewBag.Clientes = _context.Clientes.Where(c => c.Estado == 1).ToList();
                ViewBag.Productos = _context.Productos.Where(p => p.Estado == 1).ToList();
                ViewBag.TipoPagos = _context.TipoPagos.Where(t => t.Estado == 1).ToList();
                return View(ventum);
            }

            // Recalcula el total de cada detalle y el total general
            decimal totalVenta = 0;
            foreach (var d in detalles)
            {
                d.total = d.cantidad * d.precioUnitario;
                totalVenta += d.total;
            }
            ventum.MontoTotal = totalVenta;

            // Solo pon a 0 si NO es efectivo
            if (ventum.IdTipoPago == 1) // Efectivo
            {
                ventum.MontoCambio = ventum.MontoPago - ventum.MontoTotal;
                if (ventum.MontoCambio < 0) ventum.MontoCambio = 0;
            }
            else
            {
                ventum.MontoPago = 0;
                ventum.MontoCambio = 0;
            }

            ventum.FechaRegistro = DateTime.Now;
            ventum.UsuarioRegistro = User.Identity?.Name ?? "sistema";
            ventum.Estado = 1;

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Usuario1 == User.Identity.Name);
            if (usuario == null)
            {
                ModelState.AddModelError("", "No se pudo identificar el usuario actual.");
                ViewBag.Clientes = _context.Clientes.Where(c => c.Estado == 1).ToList();
                ViewBag.Productos = _context.Productos.Where(p => p.Estado == 1).ToList();
                ViewBag.TipoPagos = _context.TipoPagos.Where(t => t.Estado == 1).ToList();
                return View(ventum);
            }
            ventum.IdUsuario = usuario.Id;

            _context.Venta.Add(ventum);
            await _context.SaveChangesAsync();

            foreach (var d in detalles)
            {
                var detalle = new VentaDetalle
                {
                    IdVenta = ventum.Id,
                    IdProducto = d.idProducto,
                    Cantidad = d.cantidad,
                    PrecioUnitario = d.precioUnitario,
                    Total = d.total,
                    UsuarioRegistro = ventum.UsuarioRegistro,
                    FechaRegistro = DateTime.Now,
                    Estado = 1
                };
                _context.VentaDetalles.Add(detalle);
            }
            await _context.SaveChangesAsync();

            ViewBag.Mensaje = "Venta guardada correctamente.";
            return RedirectToAction(nameof(Index));
        }
        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var venta = await _context.Venta.FindAsync(id);
            if (venta == null)
                return NotFound();

            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", venta.IdCliente);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Usuario1", venta.IdUsuario);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPagos, "Id", "Descripcion", venta.IdTipoPago);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,IdCliente,IdTipoPago,MontoTotal,MontoPago,MontoCambio,UsuarioRegistro,FechaRegistro,Estado")] Ventum ventum)
        {
            if (id != ventum.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Venta.Any(e => e.Id == ventum.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", ventum.IdCliente);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Usuario1", ventum.IdUsuario);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPagos, "Id", "Descripcion", ventum.IdTipoPago);
            return View(ventum);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var venta = await _context.Venta
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdUsuarioNavigation)
                .Include(v => v.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (venta == null)
                return NotFound();

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Venta.FindAsync(id);
            if (venta != null)
            {
                var detalles = _context.VentaDetalles.Where(d => d.IdVenta == id);
                _context.VentaDetalles.RemoveRange(detalles);
                _context.Venta.Remove(venta);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
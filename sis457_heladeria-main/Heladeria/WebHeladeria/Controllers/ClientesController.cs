using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHeladeria.Models;

namespace WebHeladeria.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly FinalHeladeriaContext _context;

        public ClientesController(FinalHeladeriaContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            bool existe = await _context.Clientes.AnyAsync(c => c.Nit == cliente.Nit && c.Estado == 1);

            if (existe)
            {
                ModelState.AddModelError("Nit", "Ya existe un cliente con ese NIT.");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(cliente.Nit)
                    && !string.IsNullOrWhiteSpace(cliente.Nombre))
                {
                    cliente.UsuarioRegistro = User.Identity.Name;
                    cliente.FechaRegistro = DateTime.Now;
                    cliente.Estado = 1;
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = "Cliente agregado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Nit,Celular,UsuarioRegistro,FechaRegistro,Estado")] Cliente cliente)
        {
            if (id != cliente.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    cliente.UsuarioRegistro = User.Identity.Name;
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                // Verifica si el cliente tiene ventas asociadas
                bool tieneVentas = await _context.Venta.AnyAsync(v => v.IdCliente == id);
                if (tieneVentas)
                {
                    TempData["Error"] = "No se puede eliminar el cliente porque tiene ventas asociadas.";
                    return RedirectToAction(nameof(Index));
                }

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
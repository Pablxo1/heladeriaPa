using System;
using System.Collections.Generic;

namespace WebHeladeria.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string Nit { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Direccion { get; set; }

    public string TipoProducto { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}

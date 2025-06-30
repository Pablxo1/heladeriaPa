using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebHeladeria.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdSabor { get; set; }

    public int? IdProveedor { get; set; }

    public int? IdPresentacion { get; set; }

    public decimal Precio { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();

    public virtual Presentacion? IdPresentacionNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }

    public virtual Sabor? IdSaborNavigation { get; set; }

}

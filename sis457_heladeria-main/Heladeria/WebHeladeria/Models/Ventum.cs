using System;
using System.Collections.Generic;

namespace WebHeladeria.Models;

public partial class Ventum
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdCliente { get; set; }

    public int IdTipoPago { get; set; }

    public decimal MontoTotal { get; set; }

    public decimal MontoPago { get; set; }

    public decimal MontoCambio { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual TipoPago IdTipoPagoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}

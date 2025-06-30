using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebHeladeria.Models;

public partial class Cliente
{
    //public int Id { get; set; }

    //public string Nombre { get; set; } = null!;

    //public string Nit { get; set; } = null!;

    //public string Celular { get; set; } = null!;

    //public string UsuarioRegistro { get; set; } = null!;

    //public DateTime FechaRegistro { get; set; }

    //public short Estado { get; set; }

    //public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El NIT es obligatorio.")]
    public string Nit { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;
    public DateTime FechaRegistro { get; set; }
    public short Estado { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}

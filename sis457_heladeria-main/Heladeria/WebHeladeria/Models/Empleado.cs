using System;
using System.Collections.Generic;

namespace WebHeladeria.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int IdCargo { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

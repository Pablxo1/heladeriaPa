﻿using System;
using System.Collections.Generic;

namespace WebHeladeria.Models;

public partial class Presentacion
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}

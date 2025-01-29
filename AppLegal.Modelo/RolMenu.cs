using System;
using System.Collections.Generic;

namespace AppLegal.Modelo;

public partial class RolMenu
{
    public int RolMenuId { get; set; }

    public int? RolId { get; set; }

    public int? MenuId { get; set; }

    public bool? Permitido { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public virtual Menu? Menu { get; set; }

    public virtual Rol? Rol { get; set; }
}

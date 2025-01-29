using System;
using System.Collections.Generic;

namespace AppLegal.Modelo;

public partial class UsuarioRol
{
    public int UsuarioRolId { get; set; }

    public int? UsuarioId { get; set; }

    public int? RolId { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public bool? Activo { get; set; }

    public virtual Role? Rol { get; set; }

    public virtual Usuario? Usuario { get; set; }
}

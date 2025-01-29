using System;
using System.Collections.Generic;

namespace AppLegal.Modelo;

public partial class UsuarioRol
{
    public int UsuarioRolId { get; set; }

    public string? UsuarioId { get; set; }

    public int? RolId { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public bool? Activo { get; set; }

    public virtual Rol? Rol { get; set; }

    public virtual Usuario? Usuario { get; set; }
}

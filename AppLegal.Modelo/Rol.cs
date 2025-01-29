using System;
using System.Collections.Generic;

namespace AppLegal.Modelo;

public partial class Rol
{
    public int RolId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<RolMenu> RolMenus { get; set; } = new List<RolMenu>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}

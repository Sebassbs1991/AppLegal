using System;
using System.Collections.Generic;

namespace AppLegal.Modelo;

public partial class Menu
{
    public int MenuId { get; set; }

    public int? MenuPadreId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Url { get; set; }

    public string? Icono { get; set; }

    public int Orden { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Menu> InverseMenuPadre { get; set; } = new List<Menu>();

    public virtual Menu? MenuPadre { get; set; }

    public virtual ICollection<RolMenu> RolMenus { get; set; } = new List<RolMenu>();
}

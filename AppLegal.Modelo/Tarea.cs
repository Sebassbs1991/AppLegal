using System;
using System.Collections.Generic;

namespace AppLegal.Modelo;

public partial class Tarea
{
    public int TareaId { get; set; }

    public int? CasoId { get; set; }

    public int? ResponsableId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public string Prioridad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public bool? Activo { get; set; }

    public virtual Caso? Caso { get; set; }

    public virtual Usuario? Responsable { get; set; }
}

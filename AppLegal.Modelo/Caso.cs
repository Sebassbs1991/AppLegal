using System;
using System.Collections.Generic;

namespace AppLegal.Modelo;

public partial class Caso
{
    public int CasoId { get; set; }

    public string NumeroCaso { get; set; } = null!;

    public int? ClienteId { get; set; }

    public int? AbogadoId { get; set; }

    public string TipoCaso { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public bool? Activo { get; set; }

    public virtual Usuario? Abogado { get; set; }

    public virtual Usuario? Cliente { get; set; }

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}

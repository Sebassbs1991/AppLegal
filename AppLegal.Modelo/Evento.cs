using System;
using System.Collections.Generic;

namespace AppLegal.Modelo;

public partial class Evento
{
    public int EventoId { get; set; }

    public int? CasoId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string TipoEvento { get; set; } = null!;

    public bool? RecordatorioEnviado { get; set; }

    public bool? Activo { get; set; }

    public virtual Caso? Caso { get; set; }
}

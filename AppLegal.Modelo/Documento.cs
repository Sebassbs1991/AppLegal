using System;
using System.Collections.Generic;

namespace AppLegal.Modelo;

public partial class Documento
{
    public int DocumentoId { get; set; }

    public int? CasoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Ruta { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;

    public string? SubidoPor { get; set; }

    public DateTime? FechaSubida { get; set; }

    public bool? Activo { get; set; }

    public virtual Caso? Caso { get; set; }

    public virtual Usuario? SubidoPorNavigation { get; set; }
}

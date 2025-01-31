using System;
using System.Collections.Generic;

namespace AppLegal.Modelo;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Caso> CasoAbogados { get; set; } = new List<Caso>();

    public virtual ICollection<Caso> CasoClientes { get; set; } = new List<Caso>();

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}

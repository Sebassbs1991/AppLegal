using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLegal.DTO
{
    public class EventoDTO
    {
        public int EventoId { get; set; }

        public int? CasoId { get; set; }

        [Required(ErrorMessage = "El campo Título es requerido")]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "El campo Descripción es requerido")]
        public string? Descripcion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string TipoEvento { get; set; } = null!;

        public bool? RecordatorioEnviado { get; set; }

       
    }
}

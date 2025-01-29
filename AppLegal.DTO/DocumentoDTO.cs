using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLegal.DTO
{
    public class DocumentoDTO
    {
        public int DocumentoId { get; set; }

        public int? CasoId { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El ruta nombre es requerido")]
        public string Ruta { get; set; } = null!;

        [Required(ErrorMessage = "El campo tipo de documento es requerido")]
        public string TipoDocumento { get; set; } = null!;

        public string? SubidoPor { get; set; }

        public DateTime? FechaSubida { get; set; }

        public bool? Activo { get; set; }
    }
}

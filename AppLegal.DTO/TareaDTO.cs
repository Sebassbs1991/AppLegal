using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLegal.DTO
{
    public class TareaDTO
    {
        public int TareaId { get; set; }

        public int? CasoId { get; set; }

        public string? ResponsableId { get; set; }

        [Required(ErrorMessage = "El campo Título es requerido")]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "El campo descripción es requerido")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El fecha de vencimiento es requerido")]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "El campo prioridad es requerido")]
        public string Prioridad { get; set; } = null!;

        public string Estado { get; set; } = null!;

        [Required(ErrorMessage = "El campo fecha de creación es requerido")]
        public DateTime? FechaCreacion { get; set; }

        public bool? Activo { get; set; }

    }
}

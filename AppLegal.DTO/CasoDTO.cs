using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLegal.DTO
{
    public class CasoDTO
    {
        public int CasoId { get; set; }

        [Required(ErrorMessage = "El campo numero de caso es requerido")]
        public string NumeroCaso { get; set; } = null!;

        [Required(ErrorMessage = "El campo Tipo de caso es requerido")]
        public string TipoCaso { get; set; } = null!;

        [Required(ErrorMessage = "El campo Descripcion es requerido")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Fecha inicio es requerido")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo Fecha fin es requerido")]
        public DateTime? FechaFin { get; set; }

        [Required(ErrorMessage = "El campo Estado es requerido")]
        public string Estado { get; set; } = null!;

        public DateTime? FechaCreacion { get; set; }

        
    }
}

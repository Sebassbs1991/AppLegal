using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLegal.DTO
{
    public class SesionDTO
    {
        public string UsuarioId { get; set; } = null!;

       public string NombreUsuario { get; set; } = null!;

       public string Correo { get; set; } = null!;
    }
}

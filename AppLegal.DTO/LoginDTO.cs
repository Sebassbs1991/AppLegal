using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLegal.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "El campo correo es requerido")]
        public string Correo { get; set; } = null!;
        [Required(ErrorMessage = "El campo clave es requerido")]
        public string Clave { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppLegal.DTO
{
    public class UsuarioDTO
    {
        
        public string UsuarioId { get; set; } = null!;

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string NombreUsuario { get; set; } = null!;

        [Required(ErrorMessage = "El campo correo es requerido")]
        public string Correo { get; set; } = null!;
        [Required(ErrorMessage = "El campo clave es requerido")]
        public string Clave { get; set; } = null!;
        [Required(ErrorMessage = "El campo confirmar clave es requerido")]
        public string ConfirmarClave { get; set; } = null!;

               
    }
}

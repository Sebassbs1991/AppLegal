using AppLegal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLegal.Servicio.Contrato
{
    public interface ITareaServicio
    {
        Task<List<TareaDTO>> Lista(string buscar);
        Task<TareaDTO> Obtener(int id);
        Task<TareaDTO> Crear(TareaDTO modelo);
        Task<bool> Editar(TareaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}

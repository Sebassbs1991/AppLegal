using AppLegal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLegal.Servicio.Contrato
{
    public interface IEventoServicio
    {
        Task<List<EventoDTO>> Lista(string buscar);
        Task<EventoDTO> Obtener(int id);
        Task<EventoDTO> Crear(EventoDTO modelo);
        Task<bool> Editar(EventoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}

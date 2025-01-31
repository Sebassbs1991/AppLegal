using AppLegal.DTO;
using AppLegal.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLegal.Servicio.Contrato
{
    public interface ICasoServicio
    {
        Task<List<CasoDTO>> Lista(string buscar);
        Task<CasoDTO> Obtener(int id);
        Task<CasoDTO> Crear(CasoDTO modelo);
        Task<bool> Editar(CasoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}


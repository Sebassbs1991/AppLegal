using AppLegal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLegal.Servicio.Contrato
{
    public interface IDocumentoServicio
    {
        Task<List<DocumentoDTO>> Lista(string buscar);
        Task<DocumentoDTO> Obtener(int id);
        Task<DocumentoDTO> Crear(DocumentoDTO modelo);
        Task<bool> Editar(DocumentoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}

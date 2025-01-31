using AppLegal.DTO;

namespace AppLegal.WebAssembly.Servicios.Contrato
{
    public interface ICasoServicio
    {
        Task<ResponseDTO<List<CasoDTO>>> Lista(string buscar);
        Task<ResponseDTO<CasoDTO>> Obtener(int id);
        Task<ResponseDTO<CasoDTO>> Crear(CasoDTO modelo);
        Task<ResponseDTO<bool>> Editar(CasoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}

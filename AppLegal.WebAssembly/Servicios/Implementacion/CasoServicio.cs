using AppLegal.DTO;
using AppLegal.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace AppLegal.WebAssembly.Servicios.Implementacion
{
    public class CasoServicio : ICasoServicio
    {
        private readonly HttpClient _httpClient;
        public CasoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CasoDTO>> Crear(CasoDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync($"Caso/Crear", modelo);
            var resultado = await response.Content.ReadFromJsonAsync<ResponseDTO<CasoDTO>>();
            return resultado!;
        }

        public Task<ResponseDTO<bool>> Editar(CasoDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<bool>> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<List<CasoDTO>>> Lista(string buscar)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<CasoDTO>> Obtener(int id)
        {
            throw new NotImplementedException();
        }
    }
}

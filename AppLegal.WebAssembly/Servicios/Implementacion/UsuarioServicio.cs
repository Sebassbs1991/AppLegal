using AppLegal.DTO;
using AppLegal.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;
using System.Reflection;

namespace AppLegal.WebAssembly.Servicios.Implementacion
{
    public class UsuarioServicio: IUsuarioServicio  
    {
        private readonly HttpClient _httpClient;
        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Usuario/Autorizacion", modelo);
            var resultado = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();
            return resultado!;
        }

        public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync($"Usuario/Crear", modelo);
            var resultado = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
            return resultado!;
        }

        public async Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Editar", modelo);
            var resultado = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return resultado!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"Usuario/Lista/{rol}/{buscar}");
        }

        public async Task<ResponseDTO<UsuarioDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/Lista/{id}");
        }
    }
}

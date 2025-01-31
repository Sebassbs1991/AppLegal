using AppLegal.DTO;
using AppLegal.Servicio.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APPLegal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasoController : ControllerBase
    {
        private readonly ICasoServicio _casoServicio;

        public CasoController(ICasoServicio casoServicio)
        {
            _casoServicio = casoServicio;
        }

        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<CasoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";
                response.EsCorrecto = true;
                response.Resultado = await _casoServicio.Lista(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var response = new ResponseDTO<CasoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _casoServicio.Obtener(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CasoDTO modelo)
        {
            var response = new ResponseDTO<CasoDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _casoServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CasoDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _casoServicio.Editar(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _casoServicio.Eliminar(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
    }
}
using AppLegal.DTO;
using AppLegal.Servicio.Contrato;
using AppLegal.Servicio.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APPLegal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoServicio _eventoServicio;

        public EventoController(IEventoServicio eventoServicio)
        {
            _eventoServicio = eventoServicio;
        }

        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<EventoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";
                response.EsCorrecto = true;
                response.Resultado = await _eventoServicio.Lista(buscar);
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
            var response = new ResponseDTO<EventoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _eventoServicio.Obtener(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] EventoDTO modelo)
        {
            var response = new ResponseDTO<EventoDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _eventoServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] EventoDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _eventoServicio.Editar(modelo);
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
                response.Resultado = await _eventoServicio.Eliminar(id);
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

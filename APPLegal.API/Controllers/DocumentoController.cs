using AppLegal.DTO;
using AppLegal.Servicio.Contrato;
using Microsoft.AspNetCore.Mvc;

namespace APPLegal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoServicio _documentoServicio;

        public DocumentoController(IDocumentoServicio documentoServicio)
        {
            _documentoServicio = documentoServicio;
        }

        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<DocumentoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";
                response.EsCorrecto = true;
                response.Resultado = await _documentoServicio.Lista(buscar);
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
            var response = new ResponseDTO<DocumentoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _documentoServicio.Obtener(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] DocumentoDTO modelo)
        {
            var response = new ResponseDTO<DocumentoDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _documentoServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] DocumentoDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _documentoServicio.Editar(modelo);
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
                response.Resultado = await _documentoServicio.Eliminar(id);
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
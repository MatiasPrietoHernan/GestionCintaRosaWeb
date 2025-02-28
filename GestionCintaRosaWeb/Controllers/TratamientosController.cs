using CapaDatos.Modelos;
using CapaLogica.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionCintaRosaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientosController : ControllerBase
    {
        private readonly ITratamientosServices tratamientosServices;
        public TratamientosController(ITratamientosServices tratamientosServices)
        {
            this.tratamientosServices = tratamientosServices;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerTratamientos()
        {
            try
            {
                var tratamientos = await tratamientosServices.ObtenerTratamientos();
                return Ok(tratamientos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTratamiento(int id)
        {
            try
            {
                var tratamiento = await tratamientosServices.ObtenerTratamiento(id);
                return Ok(tratamiento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("relaciones")]
        public async Task<IActionResult> ObtenerRelacionesTratamientos()
        {
            try
            {
                var tratamientos = await tratamientosServices.ObtenerRelacionesTratamientos();
                return Ok(tratamientos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CrearTratamiento([FromBody]Tratamientos tratamiento)
        {
            try
            {
                await tratamientosServices.CrearTratamiento(tratamiento);
                return Ok("Tratamiento creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarTratamiento([FromBody]Tratamientos tratamiento)
        {
            try
            {
                await tratamientosServices.ActualizarTratamiento(tratamiento);
                return Ok("Tratamiento actualizado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTratamiento(int id)
        {
            try
            {
                await tratamientosServices.EliminarTratamiento(id);
                return Ok("Tratamiento eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

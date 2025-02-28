using CapaDatos.Modelos;
using CapaLogica.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionCintaRosaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly IPagosServices pagosServices;
        public PagosController(IPagosServices pagosServices)
        {
            this.pagosServices = pagosServices;
        }

        [Authorize(Roles = "Admin,Contador,Medico")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pagos = await pagosServices.ObtenerPagos();
                if (pagos == null)
                {
                    return NotFound();
                }
                return Ok(pagos);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,Contador,Medico")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pagos = await pagosServices.ObtenerPago(id);
                if (pagos == null)
                {
                    return NotFound();
                }
                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="Contador,Medico")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pagos pagos)
        {
            try
            {
                await pagosServices.CrearPago(pagos);
                return Ok("Pago creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Contador,Medico")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Pagos pagos)
        {
            try
            {
                await pagosServices.ActualizarPago(pagos);
                return Ok("Pago actualizado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Contador,Medico")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await pagosServices.EliminarPago(id);
                return Ok("Pago eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

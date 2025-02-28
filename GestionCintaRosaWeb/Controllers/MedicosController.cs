using CapaDatos.Modelos;
using CapaLogica.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionCintaRosaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicosServices _medicoService;
        public MedicosController(IMedicosServices medicoService)
        {
            _medicoService = medicoService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var medicos = await _medicoService.ObtenerMedicos();
                if(medicos == null)
                {
                    return NotFound();
                }
                return Ok(medicos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var medico = await _medicoService.ObtenerMedico(id);
                if (medico == null)
                {
                    return NotFound();
                }
                return Ok(medico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("consultas/{id}")]
        public async Task<IActionResult> GetConsultas(int id)
        {
            try
            {
                var medico = await _medicoService.ObtenerMedicoConsultas(id);
                if (medico == null)
                {
                    return NotFound();
                }
                return Ok(medico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Medicos medico)
        {
            try
            {
                await _medicoService.CrearMedico(medico);
                return Ok("Medico creado con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Medicos medico)
        {
            try
            {
                await _medicoService.ActualizarMedico(medico);
                return Ok("Medico actualizado con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _medicoService.EliminarMedico(id);
                return Ok("Medico eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

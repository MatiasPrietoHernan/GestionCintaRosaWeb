using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapaLogica.Interfaces;
using CapaDatos.Modelos;

namespace GestionCintaRosaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacientesServices _pacientesServices;

        public PacienteController(IPacientesServices pacientesServices)
        {
            _pacientesServices = pacientesServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pacientes = await _pacientesServices.ObtenerPacientes();
                if (pacientes == null)
                {
                    return NotFound();
                }
                return Ok(pacientes);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var paciente = await _pacientesServices.ObtenerPaciente(id);
                if (paciente == null)
                {
                    return NotFound();
                }
                return Ok(paciente);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("relaciones/{id}")]
        public async Task<IActionResult> GetRelaciones(int id)
        {
            try
            {
                var paciente = await _pacientesServices.ObtenerRelacionesPaciente(id);
                if (paciente == null)
                {
                    return NotFound();
                }
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pacientes paciente)
        {
            try
            {
                if (paciente == null)
                {
                    return BadRequest();
                }
                await _pacientesServices.CrearPaciente(paciente);
                return Ok("Paciente creado con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Pacientes paciente)
        {
            try
            {
                if (paciente == null)
                {
                    return BadRequest();
                }
                await _pacientesServices.ActualizarPaciente(paciente);
                return Ok("Paciente actualizado con éxito.");
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
                await _pacientesServices.EliminarPaciente(id);
                return Ok("Paciente eliminado con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

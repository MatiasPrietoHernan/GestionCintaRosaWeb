﻿using CapaLogica.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapaDatos.Modelos;
using Microsoft.AspNetCore.Authorization;

namespace GestionCintaRosaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultasServices _consultasServices;
        public ConsultasController(IConsultasServices consultasServices)
        {
            _consultasServices = consultasServices;
        }
        [Authorize(Roles = "Admin,Medico")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var consultas = await _consultasServices.ObtenerConsultas();
                if (consultas == null)
                {
                    return NotFound();
                }
                return Ok(consultas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,Medico")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var consulta = await _consultasServices.ObtenerConsulta(id);
                if (consulta == null)
                {
                    return NotFound();
                }
                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,Medico")]
        [HttpGet("relaciones")]
        public async Task<IActionResult> GetRelaciones()
        {
            try
            {
                var consulta = await _consultasServices.ObtenerRelacionesConsultas();
                if (consulta == null)
                {
                    return NotFound();
                }
                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Medico")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Consultas consulta)
        {
            try
            {
                if(consulta == null)
                {
                    return BadRequest("La consulta no puede ser nula.");
                }
                await _consultasServices.ActualizarConsulta(consulta);

                return Ok("Consulta actualizada con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Medico")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Consultas consulta)
        {
            try
            {
                if (consulta == null)
                {
                    return BadRequest("La consulta no puede ser nula.");
                }
                await _consultasServices.CrearConsulta(consulta);
                return Ok("Consulta creada con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Medico")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _consultasServices.EliminarConsulta(id);
                return Ok("Consulta eliminada con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

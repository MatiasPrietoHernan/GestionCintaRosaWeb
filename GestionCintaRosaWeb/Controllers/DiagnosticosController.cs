﻿using CapaDatos.Modelos;
using CapaLogica.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionCintaRosaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticosController : ControllerBase
    {
        private readonly IDiagnosticosServices diagnosticosServices;
        public DiagnosticosController(IDiagnosticosServices diagnosticosServices)
        {
            this.diagnosticosServices = diagnosticosServices;
        }
        [Authorize(Roles = "Admin,Medico")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var diagnosticos = await diagnosticosServices.ObtenerDiagnosticos();
                if(diagnosticos == null)
                {
                    return NotFound();
                }
                return Ok(diagnosticos);
            } catch(Exception ex)
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
                var diagnostico = await diagnosticosServices.ObtenerDiagnostico(id);
                if (diagnostico == null)
                {
                    return NotFound();
                }
                return Ok(diagnostico);
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
                var diagnosticos = await diagnosticosServices.ObtenerRelacionesDiagnosticos();
                if (diagnosticos == null)
                {
                    return NotFound();
                }
                return Ok(diagnosticos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="Medico")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Diagnosticos diagnostico)
        {
            try
            {
                await diagnosticosServices.CrearDiagnosticos(diagnostico);
                return Ok("Diagnostico agregado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Medico")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Diagnosticos diagnostico)
        {
            try
            {
                await diagnosticosServices.ActualizarDiagnosticos(diagnostico);
                return Ok("Diagnostico actualizado correctamente");
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
                await diagnosticosServices.EliminarDiagnosticos(id);
                return Ok("Diagnostico eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

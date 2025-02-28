using CapaDatos.Modelos;
using CapaLogica.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionCintaRosaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosServices usuarioServices;
        public UsuarioController(IUsuariosServices UsuarioServices)
        {
            this.usuarioServices = UsuarioServices;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Usuarios usuarios)
        {
            try
            {
                await usuarioServices.CrearUsuario(usuarios);
                return Ok("Usuario creado");
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("usuarios")]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            try
            {
                var usuarios = await usuarioServices.ObtenerUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            try
            {
                var usuario = await usuarioServices.ObtenerUsuario(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarUsuario([FromBody] Usuarios usuario)
        {
            try
            {
                await usuarioServices.ActualizarUsuario(usuario);
                return Ok("Usuario actualizado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            try
            {
                await usuarioServices.EliminarUsuario(id);
                return Ok("Usuario eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

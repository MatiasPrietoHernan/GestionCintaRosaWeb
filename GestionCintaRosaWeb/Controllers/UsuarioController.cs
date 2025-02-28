using CapaDatos.Modelos;
using CapaLogica.DTO;
using CapaLogica.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionCintaRosaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosServices usuarioServices;
        private readonly IAuthServices authServices;
        public UsuarioController(IUsuariosServices UsuarioServices, IAuthServices authServices)
        {
            this.usuarioServices = UsuarioServices;
            this.authServices = authServices;
        }

        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLogin usuarios)
        {
            try
            {
                var usuario = await usuarioServices.ValidarUsuario(usuarios);
                if(usuario == null)
                {
                    return Unauthorized("Usuario o contraseñas incorrectas");
                }
                var tokenRequest = new TokenRequest
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Rol = usuario.Rol 
                };
                var token = await authServices.GenerarToken(tokenRequest);
                return Ok(new { Token = token});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

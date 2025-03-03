using CapaLogica.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionCintaRosaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IValidateToken _validateToken;
        public AuthController(IValidateToken validateToken)
        {
            _validateToken = validateToken;
        }

        [HttpGet]
        [Route("verify")]
        public async Task<IActionResult> VerifyAuth()
        {
            var token = Request.Cookies["auth_token"];
            Console.WriteLine(token);

            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("❌ Token vacío o no enviado.");
                return Unauthorized(new { success = false, message = "Token no encontrado" });
            }

            bool esValido = _validateToken.ValidateJwtToken(token);
            Console.WriteLine("🧐 Token válido? " + esValido);

            if (!esValido)
            {
                Console.WriteLine("❌ Token inválido");
                return Unauthorized(new { success = false, message = "Token inválido o expirado" });
            }

            return Ok(new { success = true, message = "Autenticado" });
        }
    }
}

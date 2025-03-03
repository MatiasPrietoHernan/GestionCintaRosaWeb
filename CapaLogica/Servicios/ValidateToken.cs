using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CapaLogica.DTO;
using CapaLogica.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CapaLogica.Servicios
{
    public class ValidateToken : IValidateToken
    {
        private readonly string _secretKey;
        public ValidateToken(IOptions<JwtSettings> jwtSettings)
        {
            _secretKey = jwtSettings.Value.Key;
        }
        public bool ValidateJwtToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("❌ Token vacío.");
                return false;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            Console.WriteLine("🔑 Secret Key: " + _secretKey);

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,  // 🔥 IMPORTANTE: Validamos el Issuer
                    ValidateAudience = true, // 🔥 IMPORTANTE: Validamos el Audience
                    ValidIssuer = "CintaRosa", // 🔥 Debe coincidir con el que usaste al firmar el token
                    ValidAudience = "CintaRosaUsuarios", // 🔥 Debe coincidir con el que usaste al firmar el token
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;

                var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "id")?.Value;

                if (userId == null)
                {
                    Console.WriteLine("❌ Token inválido, no se encontró el ID.");
                    return false;
                }

                Console.WriteLine("✅ Token válido. UserID: " + userId);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error validando token: " + ex.Message);
                return false;
            }
        }

    }
}

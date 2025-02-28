using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CapaLogica.DTO;
using CapaLogica.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CapaLogica.Servicios
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration configuration;

        public AuthServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<string> GenerarToken(TokenRequest usuario)
        {
            //Tomamos la llave del appsettings.json.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            // Firmamos las credenciales.
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                 {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Rol) // Solo si usás roles
                };


            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(configuration["Jwt:ExpireMinutes"])),
                signingCredentials: credentials
            );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Interfaces;
using CapaDatos.Modelos;
using CapaLogica.DTO;
using CapaLogica.Interfaces;

namespace CapaLogica.Servicios
{
    public class UsuarioServices : IUsuariosServices
    {
        private readonly IUsuariosRepository usuariosRepository;
        public UsuarioServices(IUsuariosRepository usuariosRepository)
        {
            this.usuariosRepository = usuariosRepository;
        }
        public async Task<IEnumerable<Usuarios>> ObtenerUsuarios()
        {
            var usuarios = await usuariosRepository.ObtenerUsuariosAsync();
            if (usuarios == null)
            {
                throw new ArgumentException("No se encontraron usuarios");
            }
            return usuarios;
        }
        public async Task<Usuarios> ObtenerUsuario(int id)
        {
            var usuario = await usuariosRepository.ObtenerUsuarioAsync(id);
            if (usuario == null)
            {
                throw new ArgumentException("No se encontró el usuario");
            }
            return usuario;
        }
        public async Task CrearUsuario(Usuarios usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentException("El usuario no puede ser nulo");
            }
            if (!usuario.Email.Contains("@") || !usuario.Email.Contains("."))
            {
                throw new ArgumentException("El email no es válido");
            }
            var usuarioExistente = await usuariosRepository.ObtenerUsuariosAsync();
            if (usuarioExistente.Any(u => u.Email == usuario.Email))
            {
                throw new ArgumentException("El email ya está registrado");
            }
            if (usuario.PasswordHash.Length < 8)
            {
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres");
            }
            await usuariosRepository.CrearUsuarioAsync(usuario);
        }
        public async Task ActualizarUsuario(Usuarios usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentException("El usuario no puede ser nulo");
            }
            if (!usuario.Email.Contains("@") || !usuario.Email.Contains("."))
            {
                throw new ArgumentException("El email no es válido");
            }
            if (usuario.PasswordHash.Length < 8)
            {
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres");
            }
            await usuariosRepository.ActualizarUsuarioAsync(usuario);
        }
        public async Task EliminarUsuario(int id)
        {
            var usuario = await usuariosRepository.ObtenerUsuarioAsync(id);
            if (usuario == null)
            {
                throw new ArgumentException("No se encontró el usuario");
            }
            await usuariosRepository.EliminarUsuarioAsync(id);
        }
        public async Task<Usuarios> ValidarUsuario(UsuarioLogin usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentException("El usuario no puede ser nulo");
            }
            if (!usuario.Email.Contains("@") || !usuario.Email.Contains("."))
            {
                throw new ArgumentException("El email no es válido");
            }
            if (usuario.Password.Length < 8)
            {
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres");
            }
            var usuarioValidado = await usuariosRepository.ValidarUsuarioAsync(usuario.Email, usuario.Password);
            if (usuarioValidado == null)
            {
                throw new ArgumentException("Usuario o contraseña incorrectos");
            }
            return usuarioValidado;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Interfaces;
using CapaDatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos.Repositorios
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuarios>> ObtenerUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuarios> ObtenerUsuarioAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        public async Task CrearUsuarioAsync(Usuarios usuarios)
        {
            _context.Usuarios.Add(usuarios);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarUsuarioAsync(Usuarios usuarios)
        {
            _context.Entry(usuarios).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task EliminarUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<Usuarios> ValidarUsuarioAsync(string email, string password)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);
        }

    }
}

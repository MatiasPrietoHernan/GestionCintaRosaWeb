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
    public class ConsultasRepository : IConsultasRepository
    {
        private readonly AppDbContext _context;
        public ConsultasRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Consultas>> ObtenerConsultasAsync()
        {
            return await _context.Consultas.ToListAsync();
        }
        public async Task<Consultas> ObtenerConsultaAsync(int id)
        {
            return await _context.Consultas.FindAsync(id);
        }
        public async Task CrearConsultaAsync(Consultas consulta)
        {
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarConsultaAsync(Consultas consulta)
        {
            _context.Entry(consulta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task EliminarConsultaAsync(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Consultas>> ObtenerRelacionesConsultasAsync()
        {
            return await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Include(c => c.Pagos)
                .Include(c => c.Tratamientos)
                .Include(c => c.Diagnosticos)
                .ToListAsync();
        }
    }
}

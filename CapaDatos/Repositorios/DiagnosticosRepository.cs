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
    public class DiagnosticosRepository : IDiagnosticosRepository
    {
        private readonly AppDbContext _context;
        public DiagnosticosRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Diagnosticos>> ObtenerDiagnosticosAsync()
        {
            return await _context.Diagnosticos.ToListAsync();
        }
        public async Task<Diagnosticos> ObtenerDiagnosticoAsync(int id)
        {
            return await _context.Diagnosticos.FindAsync(id);
        }
        public async Task CrearDiagnosticoAsync(Diagnosticos diagnostico)
        {
            await _context.Diagnosticos.AddAsync(diagnostico);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarDiagnosticoAsync(Diagnosticos diagnostico)
        {
            _context.Diagnosticos.Update(diagnostico);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarDiagnosticoAsync(int id)
        {
            var diagnostico = await _context.Diagnosticos.FindAsync(id);
            _context.Diagnosticos.Remove(diagnostico);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Diagnosticos>> ObtenerRelacionesDiagnosticosAsync()
        {
            return await _context.Diagnosticos.Include(d => d.Consulta).ThenInclude(c=>c.Paciente).ToListAsync();
        }
    }
}

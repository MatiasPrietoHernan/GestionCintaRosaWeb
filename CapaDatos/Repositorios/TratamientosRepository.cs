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
    public class TratamientosRepository : ITratamientosRepository
    {
        private readonly AppDbContext _context;
        public TratamientosRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tratamientos>> ObtenerTratamientosAsync()
        {
            return await _context.Tratamientos.ToListAsync();
        }
        public async Task<Tratamientos> ObtenerTratamientoAsync(int id)
        {
            return await _context.Tratamientos.FindAsync(id);
        }
        public async Task CrearTratamientoAsync(Tratamientos tratamiento)
        {
            await _context.Tratamientos.AddAsync(tratamiento);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarTratamientoAsync(Tratamientos tratamiento)
        {
            _context.Tratamientos.Update(tratamiento);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarTratamientoAsync(int id)
        {
            var tratamiento = await _context.Tratamientos.FindAsync(id);
            _context.Tratamientos.Remove(tratamiento);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Tratamientos>> ObtenerRelacionesTratamientosAsync()
        {
            return await _context.Tratamientos.Include(t => t.Paciente).ToListAsync();
        }
    }
}

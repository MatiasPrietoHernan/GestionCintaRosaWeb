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
    public class PacientesRepository : IPacienteRepository
    {
        private readonly AppDbContext context;
        public PacientesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Pacientes>> ObtenerPacientesAsync()
        {
            return await context.Pacientes.ToListAsync();
        }
        public async Task<Pacientes> ObtenerPacienteAsync(int id)
        {
            return await context.Pacientes.FindAsync(id);
        }
        public async Task CrearPacienteAsync(Pacientes paciente)
        {
            context.Pacientes.Add(paciente);
            await context.SaveChangesAsync();
        }
        public async Task ActualizarPacienteAsync(Pacientes paciente)
        {
            context.Entry(paciente).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task EliminarPacienteAsync(int id)
        {
            var paciente = await context.Pacientes.FindAsync(id);
            context.Pacientes.Remove(paciente);
            await context.SaveChangesAsync();
        }
        public async Task<Pacientes> ObtenerRelacionesPacientesAsync(int id)
        {
            return await context.Pacientes
              .Where(p => p.Id == id) 
              .Include(p => p.Consulta)
              .Include(p => p.HistorialConsultas)
              .Include(p => p.Tratamientos)
              .Include(p => p.Usuario)
              .FirstOrDefaultAsync();
        }
    }
}

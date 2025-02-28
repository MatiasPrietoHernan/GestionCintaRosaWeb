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
    public class MedicosRepository : IMedicosRepository
    {
        private readonly AppDbContext context;
        public MedicosRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Medicos>> ObtenerMedicosAsync()
        {
            return await context.Medicos.ToListAsync();
        }
        public async Task<Medicos> ObtenerMedicoAsync(int id)
        {
            return await context.Medicos.FindAsync(id);
        }
        public async Task CrearMedicoAsync(Medicos medico)
        {
            context.Medicos.Add(medico);
            await context.SaveChangesAsync();
        }
        public async Task ActualizarMedicoAsync(Medicos medico)
        {
            context.Entry(medico).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task EliminarMedicoAsync(int id)
        {
            var medico = await context.Medicos.FindAsync(id);
            context.Medicos.Remove(medico);
            await context.SaveChangesAsync();
        }
        public async Task<Medicos> ObtenerMedicoConsultasAsync(int id)
        {
            return await context.Medicos.Include(x => x.Consultas).ThenInclude(p=> p.Paciente).FirstOrDefaultAsync(x => x.Id == id);
        }


    }
}

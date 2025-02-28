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
    public class PagosRepository : IPagosRepository
    {
        private readonly AppDbContext context;
        public PagosRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Pagos>> ObtenerPagosAsync()
        {
            return await context.Pagos.ToListAsync();
        }
        public async Task<Pagos> ObtenerPagoAsync(int id)
        {
            return await context.Pagos.FindAsync(id);
        }
        public async Task CrearPagoAsync(Pagos pagos)
        {
            context.Pagos.Add(pagos);
            await context.SaveChangesAsync();
        }
        public async Task ActualizarPagoAsync(Pagos pagos)
        {
            context.Entry(pagos).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task EliminarPagoAsync(int id)
        {
            var pagos = await context.Pagos.FindAsync(id);
            context.Pagos.Remove(pagos);
            await context.SaveChangesAsync();
        }

    }
}

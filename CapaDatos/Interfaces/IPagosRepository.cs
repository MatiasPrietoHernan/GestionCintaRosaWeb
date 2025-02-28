using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaDatos.Interfaces
{
    public interface IPagosRepository
    {
        Task<IEnumerable<Pagos>> ObtenerPagosAsync();
        Task<Pagos> ObtenerPagoAsync(int id);
        Task CrearPagoAsync(Pagos pagos);
        Task ActualizarPagoAsync(Pagos pagos);
        Task EliminarPagoAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaLogica.Interfaces
{
    public interface IPagosServices
    {
        Task<IEnumerable<Pagos>> ObtenerPagos();
        Task<Pagos> ObtenerPago(int id);
        Task CrearPago(Pagos pagos);
        Task ActualizarPago(Pagos pagos);
        Task EliminarPago(int id);
    }
}

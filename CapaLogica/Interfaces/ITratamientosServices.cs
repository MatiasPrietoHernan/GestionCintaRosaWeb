using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaLogica.Interfaces
{
    public interface ITratamientosServices
    {
        Task<IEnumerable<Tratamientos>> ObtenerTratamientos();
        Task<Tratamientos> ObtenerTratamiento(int id);
        Task CrearTratamiento(Tratamientos tratamiento);
        Task ActualizarTratamiento(Tratamientos tratamiento);
        Task EliminarTratamiento(int id);
        Task<IEnumerable<Tratamientos>> ObtenerRelacionesTratamientos();
    }
}

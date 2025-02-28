using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaDatos.Interfaces
{
    public interface ITratamientosRepository
    {
        Task<IEnumerable<Tratamientos>> ObtenerTratamientosAsync();
        Task<Tratamientos> ObtenerTratamientoAsync(int id);
        Task CrearTratamientoAsync(Tratamientos tratamiento);
        Task ActualizarTratamientoAsync(Tratamientos tratamiento);
        Task EliminarTratamientoAsync(int id);
        Task<IEnumerable<Tratamientos>> ObtenerRelacionesTratamientosAsync();
    }
}

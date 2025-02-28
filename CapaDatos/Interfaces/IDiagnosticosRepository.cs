using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaDatos.Interfaces
{
    public interface IDiagnosticosRepository
    {
        Task<IEnumerable<Diagnosticos>> ObtenerDiagnosticosAsync();
        Task<Diagnosticos> ObtenerDiagnosticoAsync(int id);
        Task CrearDiagnosticoAsync(Diagnosticos diagnostico);
        Task ActualizarDiagnosticoAsync(Diagnosticos diagnostico);
        Task EliminarDiagnosticoAsync(int id);
        Task<IEnumerable<Diagnosticos>> ObtenerRelacionesDiagnosticosAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaLogica.Interfaces
{
    public interface IDiagnosticosServices
    {
        Task<IEnumerable<Diagnosticos>> ObtenerDiagnosticos();
        Task<Diagnosticos> ObtenerDiagnostico(int id);
        Task CrearDiagnosticos(Diagnosticos diagnostico);
        Task ActualizarDiagnosticos(Diagnosticos diagnostico);
        Task EliminarDiagnosticos(int id);
        Task<IEnumerable<Diagnosticos>> ObtenerRelacionesDiagnosticos();
    }
}

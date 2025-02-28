using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaLogica.Interfaces
{
    public interface IConsultasServices
    {
        Task<IEnumerable<Consultas>> ObtenerConsultas();
        Task<Consultas> ObtenerConsulta(int id);
        Task CrearConsulta(Consultas consulta);
        Task ActualizarConsulta(Consultas consulta);
        Task EliminarConsulta(int id);
        Task<IEnumerable<Consultas>> ObtenerRelacionesConsultas();
    }
}

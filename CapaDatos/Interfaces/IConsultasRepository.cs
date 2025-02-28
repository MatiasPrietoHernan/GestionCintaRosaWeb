using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaDatos.Interfaces
{
    public interface IConsultasRepository
    {
        Task<IEnumerable<Consultas>> ObtenerConsultasAsync();
        Task<Consultas> ObtenerConsultaAsync(int id);
        Task CrearConsultaAsync(Consultas consulta);
        Task ActualizarConsultaAsync(Consultas consulta);
        Task EliminarConsultaAsync(int id);
        Task<IEnumerable<Consultas>> ObtenerRelacionesConsultasAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaDatos.Interfaces
{
    public interface IMedicosRepository
    {
        Task<IEnumerable<Medicos>> ObtenerMedicosAsync();
        Task<Medicos> ObtenerMedicoAsync(int id);
        Task CrearMedicoAsync(Medicos medico);
        Task ActualizarMedicoAsync(Medicos medico);
        Task EliminarMedicoAsync(int id);
        Task<Medicos> ObtenerMedicoConsultasAsync(int id);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaLogica.Interfaces
{
    public interface IMedicosServices
    {
        Task<IEnumerable<Medicos>> ObtenerMedicos();
        Task<Medicos> ObtenerMedico(int id);
        Task CrearMedico(Medicos medico);
        Task ActualizarMedico(Medicos medico);
        Task EliminarMedico(int id);
        Task<Medicos> ObtenerMedicoConsultas(int id);
    }
}

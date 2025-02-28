using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaLogica.Interfaces
{
    public interface IPacientesServices
    {
        Task<IEnumerable<Pacientes>> ObtenerPacientes();
        Task<Pacientes> ObtenerPaciente(int id);
        Task CrearPaciente(Pacientes paciente);
        Task ActualizarPaciente(Pacientes paciente);
        Task EliminarPaciente(int id);
        Task<Pacientes> ObtenerRelacionesPaciente(int id);
    }
}

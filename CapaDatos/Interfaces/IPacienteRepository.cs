using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaDatos.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Pacientes>> ObtenerPacientesAsync();
        Task<Pacientes> ObtenerPacienteAsync(int id);
        Task CrearPacienteAsync(Pacientes paciente);
        Task ActualizarPacienteAsync(Pacientes paciente);
        Task EliminarPacienteAsync(int id);
        Task<Pacientes> ObtenerRelacionesPacientesAsync(int id);
    }
}

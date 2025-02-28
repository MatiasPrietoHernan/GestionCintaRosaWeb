using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Interfaces;
using CapaDatos.Modelos;
using CapaLogica.Interfaces;

namespace CapaLogica.Servicios
{
    public class PacienteService : IPacientesServices
    {
        private readonly IPacienteRepository pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            this.pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<Pacientes>> ObtenerPacientes()
        {
            var pacientes = await pacienteRepository.ObtenerPacientesAsync();
            if(!pacientes.Any())
            {
                throw new ArgumentException("No se encontraron pacientes");
            }
            return pacientes;
        }

        public async Task<Pacientes> ObtenerPaciente(int id)
        {
            var paciente = await pacienteRepository.ObtenerPacienteAsync(id);
            if (paciente == null)
            {
                throw new ArgumentException("No se encontró el paciente");
            }
            return paciente;
        }

        public async Task CrearPaciente(Pacientes paciente)
        {
            if (paciente == null)
            {
                throw new ArgumentException("El paciente no puede ser nulo");
            }
            if(string.IsNullOrEmpty(paciente.Nombre))
            {
                throw new ArgumentException("El nombre del paciente no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(paciente.Apellido))
            {
                throw new ArgumentException("El apellido del paciente no puede estr vacío.");
            }
            if (string.IsNullOrEmpty(paciente.Direccion))
            {
                throw new ArgumentException("La dirección del paciente no puede quedar vacía");
            }
            if (string.IsNullOrEmpty(paciente.Email))
            {
                throw new ArgumentException("El email del paciente no puede ser nulo");
            }
            if(!paciente.Email.Contains("@") || !paciente.Email.Contains("."))
            {
                throw new ArgumentException("El email del paciente no es válido");
            }
            await pacienteRepository.CrearPacienteAsync(paciente);
        }

        public async Task ActualizarPaciente(Pacientes paciente)
        {
            if (paciente == null)
            {
                throw new ArgumentException("El paciente no puede ser nulo");
            }
            if (string.IsNullOrEmpty(paciente.Nombre))
            {
                throw new ArgumentException("El nombre del paciente no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(paciente.Apellido))
            {
                throw new ArgumentException("El apellido del paciente no puede estr vacío.");
            }
            if (string.IsNullOrEmpty(paciente.Direccion))
            {
                throw new ArgumentException("La dirección del paciente no puede quedar vacía");
            }
            if (string.IsNullOrEmpty(paciente.Email))
            {
                throw new ArgumentException("El email del paciente no puede ser nulo");
            }
            if (!paciente.Email.Contains("@") || !paciente.Email.Contains("."))
            {
                throw new ArgumentException("El email del paciente no es válido");
            }
            await pacienteRepository.ActualizarPacienteAsync(paciente);
        }

        public async Task EliminarPaciente(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id del paciente no es válido");
            }
            var paciente = await pacienteRepository.ObtenerPacienteAsync(id);
            if (paciente == null)
            {
                throw new ArgumentException("No se encontró el paciente");
            }
            await pacienteRepository.EliminarPacienteAsync(id);
        }

        public async Task<Pacientes> ObtenerRelacionesPaciente(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id del paciente no es válido");
            }
            var paciente = await pacienteRepository.ObtenerRelacionesPacientesAsync(id);
            if (paciente == null)
            {
                throw new ArgumentException("No se encontró el paciente");
            }
            return paciente;
        }


    }
}

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
    public class MedicoService : IMedicosServices
    {
        private readonly IMedicosRepository _medicosRepository;
        public MedicoService(IMedicosRepository medicosRepository)
        {
            _medicosRepository = medicosRepository;
        }
        public async Task<IEnumerable<Medicos>> ObtenerMedicos()
        {
            var medicos = await _medicosRepository.ObtenerMedicosAsync();
            if (medicos == null)
            {
                throw new ArgumentException("No se encontraron medicos");
            }
            return medicos;
        }
        public async Task<Medicos> ObtenerMedico(int id)
        {
            var medico = await _medicosRepository.ObtenerMedicoAsync(id);
            if (medico == null)
            {
                throw new ArgumentException("No se encontro el medico");
            }
            return medico;
        }
        public async Task CrearMedico(Medicos medico)
        {
            if(medico.Nombre == null || medico.Apellido == null || medico.Especialidad == null || medico.Matricula == null || medico.Email == null || medico.Telefono == null)
            {
                throw new ArgumentException("Faltan datos");
            }
            if(medico.Nombre.Length < 3 || medico.Apellido.Length < 3 || medico.Especialidad.Length < 3 || medico.Matricula.Length < 3 || medico.Email.Length < 3 || medico.Telefono.Length < 3)
            {
                throw new ArgumentException("Datos invalidos");
            }
            if(!medico.Email.Contains("@") || !medico.Email.Contains("."))
            {
                throw new ArgumentException("Email invalido");
            }
            await _medicosRepository.CrearMedicoAsync(medico);
        }
        public async Task ActualizarMedico(Medicos medico)
        {
            if (medico.Nombre == null || medico.Apellido == null || medico.Especialidad == null || medico.Matricula == null || medico.Email == null || medico.Telefono == null)
            {
                throw new ArgumentException("Faltan datos");
            }
            if (medico.Nombre.Length < 3 || medico.Apellido.Length < 3 || medico.Especialidad.Length < 3 || medico.Matricula.Length < 3 || medico.Email.Length < 3 || medico.Telefono.Length < 3)
            {
                throw new ArgumentException("Datos invalidos");
            }
            if (!medico.Email.Contains("@") || !medico.Email.Contains("."))
            {
                throw new ArgumentException("Email invalido");
            }
            await _medicosRepository.ActualizarMedicoAsync(medico);
        }
        public async Task EliminarMedico(int id)
        {
            var medico = await _medicosRepository.ObtenerMedicoAsync(id);
            if(medico == null)
            {
                throw new ArgumentException("No se encontro el medico");
            }
            await _medicosRepository.EliminarMedicoAsync(id);
        }
        public async Task<Medicos> ObtenerMedicoConsultas(int id)
        {
            var medico = await _medicosRepository.ObtenerMedicoConsultasAsync(id);
            if (medico == null)
            {
                throw new ArgumentException("No se encontro el medico");
            }
            return medico;
        }
    }
}

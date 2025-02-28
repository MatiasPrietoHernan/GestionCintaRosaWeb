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
    public class ConsultasServices : IConsultasServices
    {
        private readonly IConsultasRepository _consultasRepository;
        public ConsultasServices(IConsultasRepository consultasRepository)
        {
            _consultasRepository = consultasRepository;
        }
        public async Task<IEnumerable<Consultas>> ObtenerConsultas()
        {
            var consultas = await _consultasRepository.ObtenerConsultasAsync();
            if (consultas == null)
            {
                throw new ArgumentException("No se encontraron consultas");
            }
            return consultas;
        }
        public async Task<Consultas> ObtenerConsulta(int id)
        {
            var consulta = await _consultasRepository.ObtenerConsultaAsync(id);
            if (consulta == null)
            {
                throw new ArgumentException("No se encontró la consulta");
            }
            return consulta;
        }
        public async Task CrearConsulta(Consultas consulta)
        {
            if (consulta == null)
            {
                throw new ArgumentException("La consulta no puede ser nula");
            }
            if (string.IsNullOrEmpty(consulta.Motivo))
            {
                throw new ArgumentException("El motivo de la consulta no puede estar vacío");
            }
            if (string.IsNullOrEmpty(consulta.Observaciones))
            {
                throw new ArgumentException("La observación de la consulta no puede estar vacío");
            }
            if (string.IsNullOrEmpty(consulta.Fecha))
            {
                throw new ArgumentException("La fecha de la consulta no puede estar vacío");
            }
            await _consultasRepository.CrearConsultaAsync(consulta);
        }
        public async Task ActualizarConsulta(Consultas consulta)
        {
            if (consulta == null)
            {
                throw new ArgumentException("La consulta no puede ser nula");
            }
            if (string.IsNullOrEmpty(consulta.Motivo))
            {
                throw new ArgumentException("El motivo de la consulta no puede estar vacío");
            }
            if (string.IsNullOrEmpty(consulta.Observaciones))
            {
                throw new ArgumentException("La observación de la consulta no puede estar vacío");
            }
            if (string.IsNullOrEmpty(consulta.Fecha))
            {
                throw new ArgumentException("La fecha de la consulta no puede estar vacío");
            }
            await _consultasRepository.ActualizarConsultaAsync(consulta);

        }
        public async Task EliminarConsulta(int id)
        {
            var consulta = await _consultasRepository.ObtenerConsultaAsync(id);
            if (consulta == null)
            {
                throw new ArgumentException("No se encontró la consulta");
            }
            await _consultasRepository.EliminarConsultaAsync(id);
        }
        public async Task<IEnumerable<Consultas>> ObtenerRelacionesConsultas()
        {
            var consultas = await _consultasRepository.ObtenerRelacionesConsultasAsync();
            if (consultas == null)
            {
                throw new ArgumentException("No se encontraron consultas");
            }
            return consultas;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;
using CapaLogica.Interfaces;
using CapaDatos.Interfaces;

namespace CapaLogica.Servicios
{
    public class DiagnosticosServices : IDiagnosticosServices
    {
        private readonly IDiagnosticosRepository _diagnosticosRepository;
        public DiagnosticosServices(IDiagnosticosRepository diagnosticosrRepository)
        {
            _diagnosticosRepository = diagnosticosrRepository;
        }
        public async Task<IEnumerable<Diagnosticos>> ObtenerDiagnosticos()
        {
            var diagnosticos = await _diagnosticosRepository.ObtenerDiagnosticosAsync();
            if (diagnosticos == null)
            {
                throw new ArgumentException("No se encontraron diagnosticos");
            }
            return diagnosticos;
        }
        public async Task<Diagnosticos> ObtenerDiagnostico(int id)
        {
            var diagnostico = await _diagnosticosRepository.ObtenerDiagnosticoAsync(id);
            if (diagnostico == null)
            {
                throw new ArgumentException("No se encontro el diagnostico");
            }
            return diagnostico;
        }
        public async Task CrearDiagnosticos(Diagnosticos diagnostico)
        {
            if (diagnostico == null)
            {
                throw new ArgumentException("El diagnostico no puede ser nulo");
            }
            if (string.IsNullOrEmpty(diagnostico.Descripcion))
            {
                throw new ArgumentException("La descripcion del diagnostico no puede ser nula o vacia");
            }
            if (diagnostico.FechaDiagnostico < DateTime.Today)
            {
                throw new ArgumentException("No puede asignar una fecha anterior a la actual.");
            }
            await _diagnosticosRepository.CrearDiagnosticoAsync(diagnostico);
        }
        public async Task ActualizarDiagnosticos(Diagnosticos diagnostico)
        {
            if (diagnostico == null)
            {
                throw new ArgumentException("El diagnostico no puede ser nulo");
            }
            if (string.IsNullOrEmpty(diagnostico.Descripcion))
            {
                throw new ArgumentException("La descripcion del diagnostico no puede ser nula o vacia");
            }
            if (diagnostico.FechaDiagnostico < DateTime.Today)
            {
                throw new ArgumentException("No puede asignar una fecha anterior a la actual.");
            }
            await _diagnosticosRepository.ActualizarDiagnosticoAsync(diagnostico);
        }
        public async Task EliminarDiagnosticos(int id)
        {
            var diagnostico = await _diagnosticosRepository.ObtenerDiagnosticoAsync(id);
            if (diagnostico == null)
            {
                throw new ArgumentException("No se encontro el diagnostico");
            }
            await _diagnosticosRepository.EliminarDiagnosticoAsync(id);
        }
        public async Task<IEnumerable<Diagnosticos>> ObtenerRelacionesDiagnosticos()
        {
            var diagnosticos = await _diagnosticosRepository.ObtenerRelacionesDiagnosticosAsync();
            if (diagnosticos == null)
            {
                throw new ArgumentException("No se encontraron diagnosticos");
            }
            return diagnosticos;
        }
    }
}

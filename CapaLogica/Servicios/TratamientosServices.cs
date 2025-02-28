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
    public class TratamientosServices : ITratamientosServices
    {
        private readonly ITratamientosRepository tratamientosRepository;
        public TratamientosServices(ITratamientosRepository tratamientosRepository)
        {
            this.tratamientosRepository = tratamientosRepository;
        }
        public async Task<IEnumerable<Tratamientos>> ObtenerTratamientos()
        {
            var tratamientos = await tratamientosRepository.ObtenerTratamientosAsync();
            if (tratamientos == null)
            {
                throw new ArgumentException("No se encontraron tratamientos");
            }
            return tratamientos;
        }
        public async Task<Tratamientos> ObtenerTratamiento(int id)
        {
            var tratamiento = await tratamientosRepository.ObtenerTratamientoAsync(id);
            if (tratamiento == null)
            {
                throw new ArgumentException("No se encontró el tratamiento");
            }
            return tratamiento;
        }
        public async Task CrearTratamiento(Tratamientos tratamiento)
        {
            if (string.IsNullOrEmpty(tratamiento.NombreTratamiento))
            {
                throw new ArgumentException("El nombre del tratamiento es requerido");
            }
            if (string.IsNullOrEmpty(tratamiento.Detalles))
            {
                throw new ArgumentException("Los detalles del tratamiento son requeridos");
            }
            if (tratamiento.FechaInicio == null)
            {
                throw new ArgumentException("La fecha de inicio del tratamiento es requerida");
            }
            if (tratamiento.FechaFin == null)
            {
                throw new ArgumentException("La fecha de fin del tratamiento es requerida");
            }
            if (tratamiento.FechaInicio == tratamiento.FechaFin)
            {
                throw new ArgumentException("La fecha de inicio y fin del tratamiento no pueden ser iguales");
            }
            await tratamientosRepository.CrearTratamientoAsync(tratamiento);
        }
        public async Task ActualizarTratamiento(Tratamientos tratamiento)
        {
            if (string.IsNullOrEmpty(tratamiento.NombreTratamiento))
            {
                throw new ArgumentException("El nombre del tratamiento es requerido");
            }
            if (string.IsNullOrEmpty(tratamiento.Detalles))
            {
                throw new ArgumentException("Los detalles del tratamiento son requeridos");
            }
            if (tratamiento.FechaInicio == null)
            {
                throw new ArgumentException("La fecha de inicio del tratamiento es requerida");
            }
            if (tratamiento.FechaFin == null)
            {
                throw new ArgumentException("La fecha de fin del tratamiento es requerida");
            }
            if (tratamiento.FechaInicio == tratamiento.FechaFin)
            {
                throw new ArgumentException("La fecha de inicio y fin del tratamiento no pueden ser iguales");
            }
            await tratamientosRepository.ActualizarTratamientoAsync(tratamiento);
        }
        public async Task EliminarTratamiento(int id)
        {
            var tratamiento = await tratamientosRepository.ObtenerTratamientoAsync(id);
            if (tratamiento == null)
            {
                throw new ArgumentException("No se encontró el tratamiento");
            }
            await tratamientosRepository.EliminarTratamientoAsync(id);
        }
        public async Task<IEnumerable<Tratamientos>> ObtenerRelacionesTratamientos()
        {
            var tratamientos = await tratamientosRepository.ObtenerRelacionesTratamientosAsync();
            if (tratamientos == null)
            {
                throw new ArgumentException("No se encontraron tratamientos");
            }
            return tratamientos;
        }
    }
}

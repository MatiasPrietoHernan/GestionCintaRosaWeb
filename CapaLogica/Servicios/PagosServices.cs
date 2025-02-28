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
    public class PagosServices : IPagosServices
    {
        private readonly IPagosRepository pagosRepository;
        public PagosServices(IPagosRepository pagosRepository)
        {
            this.pagosRepository = pagosRepository;
        }
        public async Task<IEnumerable<Pagos>> ObtenerPagos()
        {
            var pagos = await pagosRepository.ObtenerPagosAsync();
            if(pagos == null)
            {
                throw new ArgumentException("No se encontraron pagos");
            }
            return pagos;
        }
        public async Task<Pagos> ObtenerPago(int id)
        {
            var pago = await pagosRepository.ObtenerPagoAsync(id);
            if (pago == null)
            {
                throw new ArgumentException("No se encontró el pago");
            }
            return pago;
        }
        public async Task CrearPago(Pagos pagos)
        {
            if (string.IsNullOrEmpty(pagos.MetodoPago))
            {
                throw new ArgumentException("El método de pago es requerido");
            }
            if(pagos.Monto <= 0)
            {
                throw new ArgumentException("El monto debe ser mayor a 0");
            }
            if(pagos.FechaPago == null)
            {
                throw new ArgumentException("La fecha de pago es requerida");
            }
            await pagosRepository.CrearPagoAsync(pagos);
        }
        public async Task ActualizarPago(Pagos pagos)
        {
            if (string.IsNullOrEmpty(pagos.MetodoPago))
            {
                throw new ArgumentException("El método de pago es requerido");
            }
            if (pagos.Monto <= 0)
            {
                throw new ArgumentException("El monto debe ser mayor a 0");
            }
            if (pagos.FechaPago == null)
            {
                throw new ArgumentException("La fecha de pago es requerida");
            }
            await pagosRepository.ActualizarPagoAsync(pagos);
        }
        public async Task EliminarPago(int id)
        {
            var pago = await pagosRepository.ObtenerPagoAsync(id);
            if(pago == null)
            {
                throw new ArgumentException("No se encontró el pago");
            }   
            await pagosRepository.EliminarPagoAsync(id);
        }
    }
}

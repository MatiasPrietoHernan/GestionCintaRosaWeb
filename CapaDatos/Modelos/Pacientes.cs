using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaDatos.Modelos
{
    public class Pacientes 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int DNI { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoSangre { get; set; }

        // Agregar la propiedad Consulta para la relación uno a muchos
        public ICollection<Consultas>? Consulta { get; set; }
        public ICollection<HistorialConsultas>? HistorialConsultas { get; set; }
        public ICollection<Tratamientos>? Tratamientos { get; set; }
        public int? UsuarioId { get; set; }
        public Usuarios? Usuario { get; set; }
    }
}

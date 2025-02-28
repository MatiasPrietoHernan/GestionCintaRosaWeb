using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Modelos
{
    public class Medicos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string Matricula { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        // Relación con consultas
        public ICollection<Consultas>? Consultas { get; set; }
        public int? UsuarioId { get; set; }
        public Usuarios? Usuario { get; set; }
    }
}

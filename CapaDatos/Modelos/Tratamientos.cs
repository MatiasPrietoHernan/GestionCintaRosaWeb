using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Modelos
{
    public class Tratamientos
    {
        public int Id { get; set; }
        public string NombreTratamiento { get; set; }

        // Si es opcional o no, acordate de usar int? o int según convenga.
        public int? IdConsulta { get; set; }
        public Consultas Consulta { get; set; }

        // Aquí solo dejamos IdPaciente para la relación con Pacientes.
        // Si es obligatorio, lo cambias a int en lugar de int?
        public int IdPaciente { get; set; }
        public Pacientes Paciente { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Detalles { get; set; }
    }
}

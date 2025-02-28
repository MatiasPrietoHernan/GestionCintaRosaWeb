using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Modelos
{
    public class Diagnosticos 
    {
        public int Id { get; set; }
        public int IdConsulta { get; set; }
        public Consultas Consulta { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDiagnostico { get; set; }


    }
}

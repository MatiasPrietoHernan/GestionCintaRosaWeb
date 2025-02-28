using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaLogica.Interfaces
{
    public interface IUsuariosServices
    {
        Task<IEnumerable<Usuarios>> ObtenerUsuarios();
        Task<Usuarios> ObtenerUsuario(int id);
        Task CrearUsuario(Usuarios usuario);
        Task ActualizarUsuario(Usuarios usuario);
        Task EliminarUsuario(int id);

    }
}

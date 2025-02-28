using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Modelos;

namespace CapaDatos.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<Usuarios>> ObtenerUsuariosAsync();
        Task<Usuarios> ObtenerUsuarioAsync(int id);
        Task CrearUsuarioAsync(Usuarios usuarios);
        Task ActualizarUsuarioAsync(Usuarios usuarios);
        Task EliminarUsuarioAsync(int id);
    }
}

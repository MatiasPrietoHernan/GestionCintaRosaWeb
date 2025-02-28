using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica.DTO;

namespace CapaLogica.Interfaces
{
    public interface IAuthServices
    {
        Task<string> GenerarToken(TokenRequest usuario);

    }
}

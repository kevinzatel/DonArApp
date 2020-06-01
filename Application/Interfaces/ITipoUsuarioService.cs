using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public interface ITipoUsuarioService
    {
        Task<List<TipoUsuario>> List();
    }
}

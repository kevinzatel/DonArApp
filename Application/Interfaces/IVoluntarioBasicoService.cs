using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public interface IVoluntarioBasicoService
    {
        Task<List<VoluntarioBasico>> List();
        Task<VoluntarioBasico> Get(int id);
        Task Add(VoluntarioBasico voluntarioBasico);
        Task<int> ObtenerVoluntarioIdConMenosTareas();
    }
}

using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVoluntarioAsociacionService
    {
        Task<List<VoluntarioAsociacion>> List();
        Task<VoluntarioAsociacion> Get(int id);
        VoluntarioAsociacion Get(string correo);
        Task Add(VoluntarioAsociacion va);
        Task<VoluntarioAsociacion> Update(VoluntarioAsociacion va);
    }
}

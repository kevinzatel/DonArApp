using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{


    public interface IDonacionService
    {
        Task<List<Donacion>> List();
        Task<Donacion> Get(int id);
        Task Add(Donacion donacion);
    }

}

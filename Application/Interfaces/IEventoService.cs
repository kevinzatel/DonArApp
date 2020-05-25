using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public interface IEventoService
    {
        Task<Evento> Add(Evento evento);
        Task<Evento> Update(Evento evento);
    }
}

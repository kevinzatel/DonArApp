using Application.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public interface IEventoService
    {
        Task<Evento> Get(int id);
        Task<EventoDto> GetDto(int id);
        Task<List<Evento>> List();
        Task<List<EventoDto>> ListDto();
        Task<List<Evento>> ListEventosByVoluntarioId(int id);
        Task<Evento> Add(Evento evento);
        Task<Evento> AsignarEspecialidad(int eventoId, int especialidadId);
        Task<Evento> Update(Evento evento);
    }
}

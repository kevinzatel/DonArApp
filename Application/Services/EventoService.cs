using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public class EventoService : IEventoService
    {
        private readonly DataContext _context;
        private readonly IVoluntarioBasicoService _voluntarioBasicoService;
        private readonly IVoluntarioMedicoService _voluntarioMedicoService;

        public EventoService(DataContext context, IVoluntarioBasicoService voluntarioBasicoService, IVoluntarioMedicoService voluntarioMedicoService)
        {
            _context = context;
            _voluntarioBasicoService = voluntarioBasicoService;
            _voluntarioMedicoService = voluntarioMedicoService;
        }

        public async Task<Evento> Get(int id)
        {
            var eventos = await _context.Eventos.FindAsync(id);
            return eventos;
        }

        public async Task<List<Evento>> List()
        {
            var eventos = await _context.Eventos.ToListAsync();
            return eventos;
        }

        public async Task<List<Evento>> ListEventosByVoluntarioId(int id)
        {
            var eventos = await _context.Eventos.Where(e => e.VoluntarioBasicoId == id || e.VoluntarioMedicoId == id).ToListAsync();
            return eventos;
        }

        public async Task<Evento> Add(Evento evento)
        {
            var voluntarioId = await _voluntarioBasicoService.ObtenerVoluntarioIdConMenosTareas();
            evento.VoluntarioBasicoId = voluntarioId;
            evento.Estado = EstadoEventoEnum.CREADO;
            await _context.Eventos.AddAsync(evento);
            _context.SaveChanges();
            return evento;
        }

        public async Task<Evento> AsignarEspecialidad(int eventoId, int especialdiadId)
        {
            var voluntarioId = await _voluntarioMedicoService.ObtenerMedicoDisponible(especialdiadId);
            var evento = await Get(eventoId);
            evento.VoluntarioMedicoId = voluntarioId;
            evento.VoluntarioBasicoId = null;
            _context.Eventos.Update(evento);
            _context.SaveChanges();
            return evento;
        }

        public async Task<Evento> Update(Evento evento)
        {
            var voluntarioId = await _voluntarioMedicoService.ObtenerMedicoDisponible(evento.EspecialidadId.Value);
            if(voluntarioId != -1)
            {
                evento.VoluntarioMedicoId = voluntarioId;
                evento.VoluntarioBasicoId = null;
            }
            _context.Eventos.Update(evento);
            _context.SaveChanges();
            return evento;
        }
    }
}

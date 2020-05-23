using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public class EventoService : IEventoService
    {
        private readonly DataContext _context;
        private readonly IVoluntarioBasicoService _voluntarioBasicoService;

        public EventoService(DataContext context, IVoluntarioBasicoService voluntarioBasicoService)
        {
            _context = context;
            _voluntarioBasicoService = voluntarioBasicoService;
        }

        public async Task<Evento> Add(Evento evento)
        {
            var voluntarioId = await _voluntarioBasicoService.ObtenerVoluntarioIdConMenosTareas();
            evento.VoluntarioBasicoId = voluntarioId;
            await _context.Eventos.AddAsync(evento);
            _context.SaveChanges();
            return evento;
        }
    }
}

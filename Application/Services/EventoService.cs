using Application.Dto;
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
        private readonly IPacienteService _pacienteService;

        public EventoService(DataContext context, IVoluntarioBasicoService voluntarioBasicoService, IVoluntarioMedicoService voluntarioMedicoService, IPacienteService pacienteService)
        {
            _context = context;
            _voluntarioBasicoService = voluntarioBasicoService;
            _voluntarioMedicoService = voluntarioMedicoService;
            _pacienteService = pacienteService;
        }

        public async Task<Evento> Get(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            return evento;
        }

        public async Task<EventoDto> GetDto(int id)
        {

           var evento = await Get(id);
            if (evento != null)
            {
                var paciente = await _pacienteService.Get(evento.PacienteId);
                var voluntarioMedicoId = evento.VoluntarioMedicoId ?? -1;
                var medico = voluntarioMedicoId != -1 ? await _voluntarioMedicoService.Get(voluntarioMedicoId) : null;
                var eventoDto = new EventoDto
                {
                    Id = evento.Id,
                    Fecha = evento.Fecha,
                    NombrePaciente = paciente.Nombre,
                    ApellidoPaciente = paciente.Apellido,
                    NombreMedico = medico != null ? medico.Nombre : null,
                    ApellidoMedico = medico != null ? medico.Apellido : null
                };
            return eventoDto;
            }
            return null;
        }

        public async Task<List<Evento>> List()
        {
            var eventos = await _context.Eventos.ToListAsync();
            return eventos;
        }

        public async Task<List<EventoDto>> ListDto()
        {
            var eventosDto = new List<EventoDto>();
            var eventos = await List();
            foreach (var evento in eventos)
            {
                var eventoDto = await GetDto(evento.Id);
                eventosDto.Add(eventoDto);
            }
            return eventosDto;
        }

        public async Task<List<Evento>> ListEventosByVoluntarioId(int id)
        {
            var eventos = await _context.Eventos.Where(e => e.VoluntarioBasicoId == id || e.VoluntarioMedicoId == id).ToListAsync();
            return eventos;
        }

        public async Task<List<Evento>> ListEventosByPacienteId(int id)
        {
            var eventos = await _context.Eventos.Where(e => e.PacienteId == id).ToListAsync();
            return eventos;
        }

        public async Task<List<EventoDto>> ListEventosDtoByVoluntarioId(int id)
        {
            var eventosDto = new List<EventoDto>();
            var eventosDeVoluntario = await ListEventosByVoluntarioId(id);
            foreach (var evento in eventosDeVoluntario)
            {
                var eventoDto = await GetDto(evento.Id);
                eventosDto.Add(eventoDto);
            }
            return eventosDto;
        }

        public async Task<List<EventoDto>> ListEventosDtoByPacienteId(int id)
        {
            var eventosDto = new List<EventoDto>();
            var eventosDePaciente = await ListEventosByPacienteId(id);
            foreach (var evento in eventosDePaciente)
            {
                var eventoDto = await GetDto(evento.Id);
                eventosDto.Add(eventoDto);
            }
            return eventosDto;
        }

        public async Task<Evento> Add(Evento evento)
        {
            var voluntarioId = await _voluntarioBasicoService.ObtenerVoluntarioIdConMenosTareas();
            evento.VoluntarioBasicoId = voluntarioId;
            evento.Estado = EstadoEventoEnum.PENDIENTE;
            await _context.Eventos.AddAsync(evento);
            _context.SaveChanges();
            return evento;
        }

        public async Task<Evento> AsignarEspecialidad(int eventoId, int especialdiadId)
        {
            var voluntarioId = await _voluntarioMedicoService.ObtenerMedicoDisponible(especialdiadId);
            var evento = await Get(eventoId);
            evento.EspecialidadId = especialdiadId;
            evento.VoluntarioMedicoId = voluntarioId;
            evento.VoluntarioBasicoId = null;
            _context.Eventos.Update(evento);
            _context.SaveChanges();
            return evento;
        }

        public async Task<Evento> ModificarEstado(int eventoId, EstadoEventoEnum estado)
        {
            if (estado != EstadoEventoEnum.ACEPTADO && estado != EstadoEventoEnum.RECHAZADO && estado != EstadoEventoEnum.FINALIZADO) throw new Exception("Estado inválido");
            var evento = await Get(eventoId);
            if (estado == EstadoEventoEnum.FINALIZADO) evento.VoluntarioMedicoId = null;
            if (estado == EstadoEventoEnum.RECHAZADO)
            {
                await AsignarEspecialidad(evento.Id, evento.EspecialidadId.Value);
                estado = EstadoEventoEnum.PENDIENTE;
            }
            evento.Estado = estado;
            _context.Eventos.Update(evento);
            _context.SaveChanges();
            return evento;
        }

        public async Task<Evento> Update(Evento evento)
        {
            _context.Eventos.Update(evento);
            _context.SaveChanges();
            return evento;
        }
    }
}

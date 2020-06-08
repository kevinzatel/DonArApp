﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using Application.Voluntarios;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Evento>>> List()
        {
            var eventos = await _eventoService.List();
            return Ok(eventos);
        }

        [HttpGet]
        [Route("eventosDto")]
        public async Task<ActionResult<List<EventoDto>>> ListDto()
        {
            var eventosDto = await _eventoService.ListDto();
            return Ok(eventosDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> Get(int id)
        {
            var evento = await _eventoService.Get(id);
            return Ok(evento);
        }

        [HttpGet]
        [Route("eventoDto/{id}")]
        public async Task<ActionResult<EventoDto>> GetDto(int id)
        {
            var eventoDto = await _eventoService.GetDto(id);
            return Ok(eventoDto);
        }

        [Route("eventosporvoluntario/{id}")]
        public async Task<ActionResult<List<Evento>>> ListEventosByVoluntarioId(int id)
        {
            var eventos = await _eventoService.ListEventosByVoluntarioId(id);
            return Ok(eventos);
        }

        [Route("eventosdtoporvoluntario/{id}")]
        public async Task<ActionResult<List<Evento>>> ListEventosDtoByVoluntarioId(int id)
        {
            var eventosDto = await _eventoService.ListEventosDtoByVoluntarioId(id);
            return Ok(eventosDto);
        }

        [Route("eventosporpaciente/{id}")]
        public async Task<ActionResult<List<Evento>>> ListEventosByPacienteId(int id)
        {
            var eventos = await _eventoService.ListEventosByPacienteId(id);
            return Ok(eventos);
        }

        [Route("eventosdtoporpaciente/{id}")]
        public async Task<ActionResult<List<Evento>>> ListEventosDtoByPacienteId(int id)
        {
            var eventosDto = await _eventoService.ListEventosDtoByPacienteId(id);
            return Ok(eventosDto);
        }

        [Route("eventosporemailpaciente/{email}")]
        public async Task<ActionResult<List<Evento>>> ListEventosDtoByPacienteEmail(string email)
        {
            var eventos = await _eventoService.ListEventosByPacienteEmail(email);
            return Ok(eventos);
        }

        [HttpPost]
        public async Task<ActionResult<Evento>> Add(Evento evento)
        {
            var eventoCreado = await _eventoService.Add(evento);
            return Ok(eventoCreado);
        }

        [HttpPut]
        [Route("asignarEspecialidad")]
        public async Task<ActionResult<Evento>> AsignarEspecialidad(EventoEspecialidadDto eventoEspecialidadDto)
        {
            var evento = await _eventoService.AsignarEspecialidad(eventoEspecialidadDto.EventoId, eventoEspecialidadDto.EspecialidadId);
            return Ok(evento);
        }

        [HttpPut]
        [Route("modificarEstado")]
        public async Task<ActionResult<Evento>> ModificarEstado(EventoEstadoDto eventoEstadoDto)
        {
            var evento = await _eventoService.ModificarEstado(eventoEstadoDto.EventoId, eventoEstadoDto.Estado);
            return Ok(evento);
        }

        [HttpPut]
        public async Task<ActionResult<Evento>> Update(Evento evento)
        {
            var eventoCreado = await _eventoService.Update(evento);
            return Ok(eventoCreado);
        }

    }
}
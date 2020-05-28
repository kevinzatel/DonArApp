using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<ActionResult<Evento>> Add(Evento evento)
        {
            var eventoCreado = await _eventoService.Add(evento);
            return Ok(eventoCreado);
        }

        [HttpPut]
        public async Task<ActionResult<Evento>> Update(Evento evento)
        {
            var eventoCreado = await _eventoService.Update(evento);
            return Ok(eventoCreado);
        }

    }
}
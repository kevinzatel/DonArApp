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
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoluntarioBasico>>> Get()
        
        {
            var pacientes = await _pacienteService.List();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoluntarioBasico>> Get(int id)
        {
            var pacientes = await _pacienteService.Get(id);
            return Ok(pacientes);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Paciente paciente)
        {
            await _pacienteService.Add(paciente);
            return Ok();
        }
    }
}
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
        public async Task<ActionResult<IEnumerable<Paciente>>> Get()
        
        {
            var pacientes = await _pacienteService.List();
            return Ok(pacientes);
        }

        [HttpGet]
        [Route("obtenerpacientesdto")]
        public async Task<ActionResult<IEnumerable<VoluntarioBasico>>> ObtenerPacientesDto()

        {
            var pacientes = await _pacienteService.ObtenerPacientesDto();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> Get(int id)
        {
            var pacientes = await _pacienteService.Get(id);
            return Ok(pacientes);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Paciente paciente)
        {
            var p = _pacienteService.Get(paciente.Email);
            if (p == null)
            {
                await _pacienteService.Add(paciente);
                return Ok(paciente.Id);
            }
            else {
                return Ok(null);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Paciente>> Update(Paciente paciente)
        {
            var pacienteUpdateado = await _pacienteService.Update(paciente);
            return Ok(pacienteUpdateado);
        }
    }
}
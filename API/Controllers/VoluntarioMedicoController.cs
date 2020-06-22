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
    public class VoluntarioMedicoController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IVoluntarioBasicoService _voluntarioBasico;
        private readonly IVoluntarioMedicoService _voluntarioService;
        private readonly IVoluntarioAsociacionService _voluntarioAsociacion;

        public VoluntarioMedicoController(IVoluntarioMedicoService voluntarioService, IPacienteService pacienteService, IVoluntarioBasicoService voluntarioBasico, IVoluntarioAsociacionService voluntarioAsociacion)
        {
            _pacienteService = pacienteService;
            _voluntarioBasico = voluntarioBasico;
            _voluntarioService = voluntarioService;
            _voluntarioAsociacion = voluntarioAsociacion;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoluntarioMedico>>> Get()

        {
            var voluntarios = await _voluntarioService.List();
            return Ok(voluntarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoluntarioMedico>> Get(int id)
        {
            var voluntario = await _voluntarioService.Get(id);
            return Ok(voluntario);
        }

        [HttpPost]
        public async Task<ActionResult> Add(VoluntarioMedico voluntarioMedico)
        {
            var p = _pacienteService.Get(voluntarioMedico.Email);
            var vb = _voluntarioBasico.Get(voluntarioMedico.Email);
            var vm = _voluntarioService.Get(voluntarioMedico.Email);
            var va = _voluntarioAsociacion.Get(voluntarioMedico.Email);
            if (p == null && vb == null && vm == null && va == null)
            {
                await _voluntarioService.Add(voluntarioMedico);
                return Ok(voluntarioMedico.Id);
            } else
            {
                return Ok(null);
            }
        }
        [HttpPut]
        public async Task<ActionResult<VoluntarioMedico>> Update(VoluntarioMedico vm)
        {
            var vmUpdateado = await _voluntarioService.Update(vm);
            return Ok(vmUpdateado);
        }
    }
}
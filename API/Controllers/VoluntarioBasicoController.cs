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
    public class VoluntarioBasicoController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IVoluntarioBasicoService _voluntarioService;
        private readonly IVoluntarioMedicoService _voluntarioMedico;
        private readonly IVoluntarioAsociacionService _voluntarioAsociacion;

        public VoluntarioBasicoController(IVoluntarioBasicoService voluntarioService, IPacienteService pacienteService, IVoluntarioMedicoService voluntarioMedico, IVoluntarioAsociacionService voluntarioAsociacion)
        {
            _pacienteService = pacienteService;
            _voluntarioService = voluntarioService;
            _voluntarioMedico = voluntarioMedico;
            _voluntarioAsociacion = voluntarioAsociacion;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoluntarioBasico>>> Get()
        
        {
            var voluntarios = await _voluntarioService.List();
            return Ok(voluntarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoluntarioBasico>> Get(int id)
        {
            var voluntario = await _voluntarioService.Get(id);
            return Ok(voluntario);
        }

        [HttpPost]
        public async Task<ActionResult> Add(VoluntarioBasico voluntarioBasico)
        {
            var p = _pacienteService.Get(voluntarioBasico.Email);
            var vb = _voluntarioService.Get(voluntarioBasico.Email);
            var vm = _voluntarioMedico.Get(voluntarioBasico.Email);
            var va = _voluntarioAsociacion.Get(voluntarioBasico.Email);
            if (p == null && vb == null && vm == null && va == null)
            {
                await _voluntarioService.Add(voluntarioBasico);
                return Ok(voluntarioBasico.Id);
            }
            else
            {
                return Ok(null);
            }
        }
        [HttpPut]
        public async Task<ActionResult<VoluntarioBasico>> Update(VoluntarioBasico vb)
        {
            var vbUpdateado = await _voluntarioService.Update(vb);
            return Ok(vbUpdateado);
        }
    }
}
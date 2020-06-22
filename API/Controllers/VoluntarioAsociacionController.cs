using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Voluntarios;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoluntarioAsociacionController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IVoluntarioBasicoService _voluntarioBasico;
        private readonly IVoluntarioMedicoService _voluntarioMedico;
        private readonly IVoluntarioAsociacionService _voluntarioAsociacionService;

        public VoluntarioAsociacionController(IVoluntarioAsociacionService voluntarioAsociacionService, IPacienteService pacienteService, IVoluntarioBasicoService voluntarioBasico, IVoluntarioMedicoService voluntarioMedico)
        {
            _voluntarioAsociacionService = voluntarioAsociacionService;
            _pacienteService = pacienteService;
            _voluntarioBasico = voluntarioBasico;
            _voluntarioMedico = voluntarioMedico;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoluntarioAsociacion>>> Get()
        {
            var va = await _voluntarioAsociacionService.List();
            return Ok(va);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoluntarioAsociacion>> Get(int id)
        {
            var va = await _voluntarioAsociacionService.Get(id);
            return Ok(va);
        }

        [HttpPost]
        public async Task<ActionResult> Add(VoluntarioAsociacion volAsociacion)
        {
            var p = _pacienteService.Get(volAsociacion.Email);
            var vb = _voluntarioBasico.Get(volAsociacion.Email);
            var vm = _voluntarioMedico.Get(volAsociacion.Email);
            var va = _voluntarioAsociacionService.Get(volAsociacion.Email);
            if (p == null && vb == null && vm == null && va == null)
            {
                await _voluntarioAsociacionService.Add(volAsociacion);
                return Ok(volAsociacion.Id);
            }
            else {
                return Ok(null);
            }
        }

        [HttpPut]
        public async Task<ActionResult<VoluntarioAsociacion>> Update(VoluntarioAsociacion va)
        {
            var volUpdateado = await _voluntarioAsociacionService.Update(va);
            return Ok(volUpdateado);
        }
    }
}

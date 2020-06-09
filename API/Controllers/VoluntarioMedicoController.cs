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
        private readonly IVoluntarioMedicoService _voluntarioService;

        public VoluntarioMedicoController(IVoluntarioMedicoService voluntarioService)
        {
            _voluntarioService = voluntarioService;
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
            var vm = _voluntarioService.Get(voluntarioMedico.Email);
            if (vm==null)
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
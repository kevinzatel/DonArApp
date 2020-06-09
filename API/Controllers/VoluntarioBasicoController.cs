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
        private readonly IVoluntarioBasicoService _voluntarioService;

        public VoluntarioBasicoController(IVoluntarioBasicoService voluntarioService)
        {
            _voluntarioService = voluntarioService;
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
            var vb = _voluntarioService.Get(voluntarioBasico.Email);
            if (vb == null)
            {
                await _voluntarioService.Add(voluntarioBasico);
                return Ok(voluntarioBasico);
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
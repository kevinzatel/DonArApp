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
        private readonly IVoluntarioAsociacionService _voluntarioAsociacionService;

        public VoluntarioAsociacionController(IVoluntarioAsociacionService voluntarioAsociacionService)
        {
            _voluntarioAsociacionService = voluntarioAsociacionService;
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
            var va = _voluntarioAsociacionService.Get(volAsociacion.Email);
            if (va == null)
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

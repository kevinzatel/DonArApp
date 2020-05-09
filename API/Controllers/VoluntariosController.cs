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
    public class VoluntariosController : ControllerBase
    {
        private readonly IVoluntarioService _voluntarioService;

        public VoluntariosController(IVoluntarioService voluntarioService)
        {
            _voluntarioService = voluntarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voluntario>>> Get()
        
        {
            var voluntarios = await _voluntarioService.GetVoluntarios();
            return Ok(voluntarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Voluntario>> Get(int id)
        {
            var voluntario = await _voluntarioService.GetVoluntario(id);
            return Ok(voluntario);
        }
    }
}
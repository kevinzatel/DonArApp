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
    public class NacionalidadController : ControllerBase
    {
        private readonly INacionalidadService _nacionalidadService;

        public NacionalidadController(INacionalidadService nacionalidadService)
        {
            _nacionalidadService = nacionalidadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nacionalidad>>> Get()
        
        {
            var nacionalidades = await _nacionalidadService.List();
            return Ok(nacionalidades);
        }
    }
}
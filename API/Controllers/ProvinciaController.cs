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
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaService _provinciaService;

        public ProvinciaController(IProvinciaService provinciaService)
        {
            _provinciaService = provinciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provincia>>> Get()
        
        {
            var provincias = await _provinciaService.List();
            return Ok(provincias);
        }
    }
}
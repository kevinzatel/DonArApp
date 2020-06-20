using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using Application.Voluntarios;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IVoluntarioBasicoService _voluntarioService;
        private readonly IVoluntarioMedicoService _voluntarioMedicoService;
        private readonly IVoluntarioAsociacionService _voluntarioAsociacionService;

        public ReportesController(IVoluntarioBasicoService voluntarioService, IVoluntarioMedicoService voluntarioMedicoService, IVoluntarioAsociacionService voluntarioAsociacionService)
        {
            _voluntarioService = voluntarioService;
            _voluntarioMedicoService = voluntarioMedicoService;
            _voluntarioAsociacionService = voluntarioAsociacionService;
        }

        [Route("voluntarios")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoluntarioBasico>>> Get()
        
        {
            var reporteVoluntarios = new ReporteVoluntarios();
            var voluntariosBasicos = await _voluntarioService.List();
            var voluntariosMedicos = await _voluntarioMedicoService.List();
            var voluntariosAsociacion = await _voluntarioAsociacionService.List();
            reporteVoluntarios.CantVoluntariosBasicos = voluntariosBasicos.Count();
            reporteVoluntarios.CantVoluntariosMedicos = voluntariosMedicos.Count();
            reporteVoluntarios.CantVoluntariosAsociacion = voluntariosAsociacion.Count();
            return Ok(reporteVoluntarios);
        }
    }
}
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
        private readonly IPacienteService _pacientenService;

        public ReportesController(IVoluntarioBasicoService voluntarioService, IVoluntarioMedicoService voluntarioMedicoService, IVoluntarioAsociacionService voluntarioAsociacionService, IPacienteService pacienteService)
        {
            _voluntarioService = voluntarioService;
            _voluntarioMedicoService = voluntarioMedicoService;
            _voluntarioAsociacionService = voluntarioAsociacionService;
            _pacientenService = pacienteService;
        }

        [Route("voluntarios")]
        [HttpGet]
        public async Task<ActionResult<ReporteVoluntarios>> GetReporteVoluntarios()
        
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


        // Devuelve un array de 6 posiciones que representan los siguientes rangos de edades: (0-5, 6-14, 15-19, 20-44, 45-64, 65+)
        [Route("rangoEtario")]
        [HttpGet]
        public async Task<ActionResult<int[]>> GetReporteRangoEtario()

        {
            var pacientes = await _pacientenService.List();
            var reporteRangoEtario = new int[6];
            reporteRangoEtario[0] = pacientes.Where(p => p.Edad < 6).Count();
            reporteRangoEtario[1] = pacientes.Where(p => p.Edad > 5 && p.Edad < 15).Count();
            reporteRangoEtario[2] = pacientes.Where(p => p.Edad > 14 && p.Edad < 20).Count();
            reporteRangoEtario[3] = pacientes.Where(p => p.Edad > 19 && p.Edad < 45).Count();
            reporteRangoEtario[4] = pacientes.Where(p => p.Edad > 44 && p.Edad < 65).Count();
            reporteRangoEtario[5] = pacientes.Where(p => p.Edad > 64).Count();

            return Ok(reporteRangoEtario);
        }
    }
}
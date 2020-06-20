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
        private readonly IReporteService _reporteService;

        public ReportesController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [Route("voluntarios")]
        [HttpGet]
        public async Task<ActionResult<ReporteVoluntarios>> GetReporteVoluntarios()
        {
            var reporteVoluntarios = await _reporteService.GetReporteVoluntarios();
            return Ok(reporteVoluntarios);
        }


        // Devuelve un array de 6 posiciones que representan los siguientes rangos de edades: (0-5, 6-14, 15-19, 20-44, 45-64, 65+)
        [Route("rangoEtario")]
        [HttpGet]
        public async Task<ActionResult<int[]>> GetReporteRangoEtario()
        {
            var reporteRangoEtario = await _reporteService.GetReporteRangoEtario();
            return Ok(reporteRangoEtario);
        }
    }
}
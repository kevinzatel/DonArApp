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
    public class DonacionController : ControllerBase
    {
        private readonly IDonacionService _donacionService;

        public DonacionController(IDonacionService donacionService)
        {
            _donacionService = donacionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Donacion>>> List()
        {
            var donaciones = await _donacionService.List();
            return Ok(donaciones);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Donacion>> Get(int id)
        {
            var donacion = await _donacionService.Get(id);
            return Ok(donacion);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Donacion donacion)
        {
            await _donacionService.Add(donacion);
            return Ok(donacion.Id);
        }

        [Route("donacionesporusuario/{id}")]
        public async Task<ActionResult<List<Donacion>>> ListDonacionesByUserId(int id)
        {
            List<Donacion> donaciones = await _donacionService.ListDonacionesByUserId(id);
            return Ok(donaciones);
        }

        [Route("historicodonacion/{id}")]
        public async Task<ActionResult<List<HistoricoDonacion>>> ListHstoricoDonacion(int id)
        {
            List<HistoricoDonacion> historicoDonacion = await _donacionService.ListHistoricoDonacionById(id);
            return Ok(historicoDonacion);
        }

        [HttpPut]
        public async Task<ActionResult<Donacion>> Update(Donacion donacion)
        {
            var donacionUpdateada = await _donacionService.Update(donacion);
            return Ok(donacionUpdateada);
        }

    }
}
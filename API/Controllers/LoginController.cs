using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Voluntarios;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IVoluntarioBasicoService _voluntarioBasicoService;
        private readonly IVoluntarioMedicoService _voluntarioMedicoService;

        public LoginController(IPacienteService pacienteService, IVoluntarioBasicoService voluntarioBasicoService, IVoluntarioMedicoService voluntarioMedicoService)
        {
            _pacienteService = pacienteService;
            _voluntarioBasicoService = voluntarioBasicoService;
            _voluntarioMedicoService = voluntarioMedicoService;
        }
        
        [HttpGet("{correo}")]
        public async Task<ActionResult<Boolean>> Get(string correo)
        {
            Login l=new Login();
                Paciente p =  _pacienteService.Get(correo);
                VoluntarioBasico vb = await _voluntarioBasicoService.Get(correo);
                VoluntarioMedico vm = await _voluntarioMedicoService.Get(correo);
                if (p != null || vb!=null || vm!=null) {
                l.inicio = 1;
                } else {
                l.inicio = 0;
                }
            return Ok(l);
        }
        [HttpPut("{correo}")]
        public async Task<ActionResult<Login>> Put(string correo, string IdGoogle)
        {
            Login l = new Login();
            Paciente p =  _pacienteService.Get(correo);
            VoluntarioBasico vb = await _voluntarioBasicoService.Get(correo);
            VoluntarioMedico vm = await _voluntarioMedicoService.Get(correo);
            if (p != null || vb != null || vm != null)
            {
                if (p.IdGoogle==null || p.IdGoogle.Equals("0")) {
                    p.IdGoogle = IdGoogle;
                    _pacienteService.Update(p);
                } else if (vb.IdGoogle==null || vb.IdGoogle.Equals("0")) {
                    vb.IdGoogle = IdGoogle;
                    _voluntarioBasicoService.Update(vb);
                } else if (vm.IdGoogle==null || vm.Id.Equals("0")) {
                    vm.IdGoogle = IdGoogle;
                    _voluntarioMedicoService.Update(vm);
                }
                l.inicio = 1;
            }
            else
            {
                l.inicio = 0;
            }
            return Ok(l);
        }
    }
}

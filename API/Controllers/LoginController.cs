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
        public async Task<ActionResult<int>> Get(string correo)
        {
                Paciente p =  _pacienteService.Get(correo);
                VoluntarioBasico vb =  _voluntarioBasicoService.Get(correo);
                VoluntarioMedico vm =  _voluntarioMedicoService.Get(correo);
            if (p != null)
            {
                return Ok(p.Id);
            }
            else if (vb != null)
            {
                return Ok(vb.Id);
            }
            else if (vm != null)
            {
                return Ok(vm.Id);
            }
            else {
                return Ok(0);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Login>> Put(ActualizaIG a)
        {
            Login l = new Login();
            Paciente p =  _pacienteService.Get(a.mail);
            VoluntarioBasico vb =  _voluntarioBasicoService.Get(a.mail);
            VoluntarioMedico vm =  _voluntarioMedicoService.Get(a.mail);

            if (p != null) {
                if (p.IdGoogle == null || p.IdGoogle.Equals("0"))
                {
                    p.IdGoogle = a.idGoogle;
                    _pacienteService.Update(p);
                }
                l.inicio = 1;
            } else if (vb!=null) {
                if (vb.IdGoogle == null || vb.IdGoogle.Equals("0")) {
                    vb.IdGoogle = a.idGoogle;
                    _voluntarioBasicoService.Update(vb);
                }
                l.inicio = 1;
            }
            else if (vm!=null)
            {
                if (vm.IdGoogle==null || vm.IdGoogle.Equals("0")) {
                    vm.IdGoogle = a.idGoogle;
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

﻿using System;
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
        private readonly IVoluntarioAsociacionService _voluntarioAsociacionService;

        public LoginController(IPacienteService pacienteService, IVoluntarioBasicoService voluntarioBasicoService, IVoluntarioMedicoService voluntarioMedicoService, IVoluntarioAsociacionService voluntarioAsociacionService)
        {
            _pacienteService = pacienteService;
            _voluntarioBasicoService = voluntarioBasicoService;
            _voluntarioMedicoService = voluntarioMedicoService;
            _voluntarioAsociacionService = voluntarioAsociacionService;
        }
        
        [HttpGet("{correo}")]
        public async Task<ActionResult<VolLogin>> Get(string correo)
        {
                 VolLogin v = new VolLogin();
                Paciente p =  _pacienteService.Get(correo);
                VoluntarioBasico vb =  _voluntarioBasicoService.Get(correo);
                VoluntarioMedico vm =  _voluntarioMedicoService.Get(correo);
                 VoluntarioAsociacion va = _voluntarioAsociacionService.Get(correo);
            if (p != null)
            {
                v.idUser = p.Id;
                v.tipoUser = p.TipoUsuarioId;
                return Ok(v);
            }
            else if (vb != null)
            {
                v.idUser = vb.Id;
                v.tipoUser = vb.TipoUsuarioId;
                return Ok(v);
            }
            else if (vm != null)
            {
                v.idUser = vm.Id;
                v.tipoUser = vm.TipoUsuarioId;
                return Ok(v);
            } else if (va != null) {
                v.idUser = va.Id;
                v.tipoUser = va.TipoUsuarioId;
                return Ok(v);
            }
            else {
                return Ok(null);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Login>> Put(ActualizaIG a)
        {
            Login l = new Login();
            Paciente p =  _pacienteService.Get(a.mail);
            VoluntarioBasico vb =  _voluntarioBasicoService.Get(a.mail);
            VoluntarioMedico vm =  _voluntarioMedicoService.Get(a.mail);
            VoluntarioAsociacion va = _voluntarioAsociacionService.Get(a.mail);
            if (p != null) {
                if (p.IdGoogle == null || p.IdGoogle.Equals("0"))
                {
                    p.IdGoogle = a.idGoogle;
                    _pacienteService.Update(p);
                }
                l.inicio = 1;
            } else if (vb != null) {
                if (vb.IdGoogle == null || vb.IdGoogle.Equals("0")) {
                    vb.IdGoogle = a.idGoogle;
                    _voluntarioBasicoService.Update(vb);
                }
                l.inicio = 1;
            }
            else if (vm != null)
            {
                if (vm.IdGoogle == null || vm.IdGoogle.Equals("0")) {
                    vm.IdGoogle = a.idGoogle;
                    _voluntarioMedicoService.Update(vm);
                }
                l.inicio = 1;
            } else if (va != null)
            {
                if (va.IdGoogle == null || va.IdGoogle.Equals("0")) {
                    va.IdGoogle = a.idGoogle;
                    _voluntarioAsociacionService.Update(va);
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

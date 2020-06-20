using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public class ReporteService : IReporteService
    {
        private readonly DataContext _context;
        private readonly IVoluntarioBasicoService _voluntarioService;
        private readonly IVoluntarioMedicoService _voluntarioMedicoService;
        private readonly IVoluntarioAsociacionService _voluntarioAsociacionService;
        private readonly IPacienteService _pacientenService;
        private readonly IEspecialidadService _especialidadService;

        public ReporteService(DataContext context, IVoluntarioBasicoService voluntarioService, IVoluntarioMedicoService voluntarioMedicoService, IVoluntarioAsociacionService voluntarioAsociacionService, IPacienteService pacienteService, IEspecialidadService especialidadService)
        {
            _context = context;
            _voluntarioService = voluntarioService;
            _voluntarioMedicoService = voluntarioMedicoService;
            _voluntarioAsociacionService = voluntarioAsociacionService;
            _pacientenService = pacienteService;
            _especialidadService = especialidadService;
        }

        public async Task<ReporteVoluntarios> GetReporteVoluntarios()
        {
            var reporteVoluntarios = new ReporteVoluntarios();
            reporteVoluntarios.MedicosPorEspecialidad = new Dictionary<string, int>();
            var voluntariosBasicos = await _voluntarioService.List();
            var voluntariosMedicos = await _voluntarioMedicoService.List();
            var voluntariosAsociacion = await _voluntarioAsociacionService.List();
            reporteVoluntarios.CantVoluntariosBasicos = voluntariosBasicos.Count();
            reporteVoluntarios.CantVoluntariosMedicos = voluntariosMedicos.Count();
            reporteVoluntarios.CantVoluntariosAsociacion = voluntariosAsociacion.Count();
            var especialidades = await _especialidadService.List();
            foreach (var especialidad in especialidades)
            {
                var medicosPorEspecialidad = voluntariosMedicos.Where(m => m.EspecialidadId == especialidad.Id).Count();
                reporteVoluntarios.MedicosPorEspecialidad.Add(especialidad.Nombre, medicosPorEspecialidad);
            }
            
            return reporteVoluntarios;
        }

        public async Task<int[]> GetReporteRangoEtario()
        {
            var pacientes = await _pacientenService.List();
            var reporteRangoEtario = new int[6];
            reporteRangoEtario[0] = pacientes.Where(p => p.Edad < 6).Count();
            reporteRangoEtario[1] = pacientes.Where(p => p.Edad > 5 && p.Edad < 15).Count();
            reporteRangoEtario[2] = pacientes.Where(p => p.Edad > 14 && p.Edad < 20).Count();
            reporteRangoEtario[3] = pacientes.Where(p => p.Edad > 19 && p.Edad < 45).Count();
            reporteRangoEtario[4] = pacientes.Where(p => p.Edad > 44 && p.Edad < 65).Count();
            reporteRangoEtario[5] = pacientes.Where(p => p.Edad > 64).Count();

            return reporteRangoEtario;
        }
    }
}

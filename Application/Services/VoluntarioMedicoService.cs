using Domain;
using Domain.Enums;
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
    public class VoluntarioMedicoService : IVoluntarioMedicoService
    {
        private readonly DataContext _context;

        public VoluntarioMedicoService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<VoluntarioMedico>> List()
        {
            var voluntarios = await _context.VoluntariosMedicos.ToListAsync();
            return voluntarios;
        }

        public async Task<VoluntarioMedico> Get(int id)
        {
            var voluntario = await _context.VoluntariosMedicos.FindAsync(id);
            return voluntario;
        }

        public async Task Add(VoluntarioMedico voluntarioMedico)
        {
            await _context.VoluntariosMedicos.AddAsync(voluntarioMedico);
            _context.SaveChanges();
        }

        public async Task<int> ObtenerMedicoDisponible(int especialidadId)
        {
            var timeFfDay = DateTime.Now.TimeOfDay;
            var voluntariosDisponibles = new List<VoluntarioMedico>();
            var voluntariosConEspecialidad = _context.VoluntariosMedicos.Where(v => v.EspecialidadId == especialidadId).ToList();
            foreach (var v in voluntariosConEspecialidad)
            {
                if(TimeSpan.Parse(v.InicioJornada) <= timeFfDay && TimeSpan.Parse(v.FinJornada) >= timeFfDay) { 
                    voluntariosDisponibles.Add(v);
                }
            }
            if (voluntariosDisponibles.Count() > 0)
            {
                var voluntarioConMenosTareas = voluntariosDisponibles.OrderBy(v => getEventos(v.Id).Count()).FirstOrDefault();
                return voluntarioConMenosTareas.Id;
            }
            return -1;
        }

        private List<Evento> getEventos(int voluntarioId)
        {
            return _context.Eventos.Where(e => e.VoluntarioMedicoId == voluntarioId).ToList();
        }
    }
}

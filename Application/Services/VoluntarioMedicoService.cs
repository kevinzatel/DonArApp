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
            var timeOfDay = DateTime.Now.TimeOfDay;
            var inicioDeJornada = new TimeSpan(9, 0, 0);
            var finDeJornada = new TimeSpan(19, 0, 0);
            var voluntariosDisponibles = new List<VoluntarioMedico>();
            var voluntariosConEspecialidad = _context.VoluntariosMedicos.Where(v => v.EspecialidadId == especialidadId).ToList();
            if (voluntariosConEspecialidad.Count == 0) throw new Exception("La base de datos no cuenta con medicos de esta especialidad");
            while (voluntariosDisponibles.Count == 0)
            {
                foreach (var v in voluntariosConEspecialidad)
                {
                    if (TimeSpan.Parse(v.InicioJornada) <= timeOfDay && TimeSpan.Parse(v.FinJornada) > timeOfDay)
                    {
                        voluntariosDisponibles.Add(v);
                    }
                }
                if (voluntariosDisponibles.Count() == 0)
                {
                    timeOfDay = timeOfDay < finDeJornada ? timeOfDay.Add(TimeSpan.FromMinutes(30)) : timeOfDay = inicioDeJornada;
                }
            }

            var voluntarioConMenosTareas = voluntariosDisponibles.OrderBy(v => getEventos(v.Id).Count()).FirstOrDefault();
            return voluntarioConMenosTareas.Id;
        }

        private List<Evento> getEventos(int voluntarioId)
        {
            return _context.Eventos.Where(e => e.VoluntarioMedicoId == voluntarioId).ToList();
        }

        public VoluntarioMedico Get(string correo)
        {
            var voluntario = _context.VoluntariosMedicos.FirstOrDefault(x => x.Email.Equals(correo));
            return voluntario;
        }

        public async Task<VoluntarioMedico> Update(VoluntarioMedico vm)
        {
            _context.VoluntariosMedicos.Update(vm);
            _context.SaveChanges();
            return vm;
        }
    }
}

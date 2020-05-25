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

        public async Task<int> ObtenerMedicoDisponible(EspecialidadEnum? especialidad)
        {
            var voluntariosDisponibles = _context.VoluntariosMedicos.Where(v => v.Especialidad == especialidad && v.InicioJornada <= DateTime.Now.Hour && v.FinJornada >= DateTime.Now.Hour).ToList();
            if(voluntariosDisponibles.Count() > 0)
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

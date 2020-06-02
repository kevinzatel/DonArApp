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
    public class VoluntarioBasicoService : IVoluntarioBasicoService
    {
        private readonly DataContext _context;

        public VoluntarioBasicoService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<VoluntarioBasico>> List()
        {
            var voluntarios = await _context.VoluntariosBasicos.ToListAsync();
            return voluntarios;
        }

        public async Task<VoluntarioBasico> Get(int id)
        {
            var voluntario = await _context.VoluntariosBasicos.FindAsync(id);
            return voluntario;
        }

        public async Task Add(VoluntarioBasico voluntarioBasico)
        {
            await _context.VoluntariosBasicos.AddAsync(voluntarioBasico);
            _context.SaveChanges();
        }

        public async Task<int> ObtenerVoluntarioIdConMenosTareas()
        {
            var voluntario = _context.VoluntariosBasicos.OrderBy(v => v.Eventos.Count()).FirstOrDefault();
            return voluntario.Id;
        }

        public async Task<VoluntarioBasico> Get(string correo)
        {
            var voluntario = await _context.VoluntariosBasicos.FirstOrDefaultAsync(x => x.Email.Equals(correo));
            return voluntario;
        }
    }
}

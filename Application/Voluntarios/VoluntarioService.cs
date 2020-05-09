using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public class VoluntarioService : IVoluntarioService
    {
        private readonly DataContext _context;

        public VoluntarioService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Voluntario>> GetVoluntarios()
        {
            var voluntarios = await _context.Voluntarios.ToListAsync();
            return voluntarios;
        }

        public async Task<Voluntario> GetVoluntario(int id)
        {
            var voluntario = await _context.Voluntarios.FindAsync(id);
            return voluntario;
        }
    }
}

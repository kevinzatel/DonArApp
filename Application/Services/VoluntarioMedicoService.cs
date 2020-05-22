using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
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
    }
}

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
    public class EspecialidadService : IEspecialidadService
    {
        private readonly DataContext _context;

        public EspecialidadService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Especialidad>> List()
        {
            var especialidades = await _context.Especialidades.ToListAsync();
            return especialidades;
        }
    }
}

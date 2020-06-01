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
    public class NacionalidadService : INacionalidadService
    {
        private readonly DataContext _context;

        public NacionalidadService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Nacionalidad>> List()
        {
            var nacionalidades = await _context.Nacionalidades.ToListAsync();
            return nacionalidades;
        }
    }
}

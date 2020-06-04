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
    public class ProvinciaService : IProvinciaService
    {
        private readonly DataContext _context;

        public ProvinciaService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Provincia>> List()
        {
            var provincias = await _context.Provincias.ToListAsync();
            return provincias;
        }
    }
}

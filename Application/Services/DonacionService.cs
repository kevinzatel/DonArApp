using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public class DonacionService : IDonacionService
    {
        private readonly DataContext _context;


        public DonacionService(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Donacion donacion)
        {
            await _context.Donaciones.AddAsync(donacion);
            _context.SaveChanges();
        }


        public async Task<Donacion> Get(int id)
        {
            var donaciones = await _context.Donaciones.FindAsync(id);
            return donaciones;
        }


        public async Task<List<Donacion>> List()
        {
            var donaciones = await _context.Donaciones.ToListAsync();
            return donaciones;
        }

    }
}

using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VoluntarioAsociacionService : IVoluntarioAsociacionService
    {
        private readonly DataContext _context;

        public VoluntarioAsociacionService(DataContext context)
        {
            _context = context;
        }
        public async Task Add(VoluntarioAsociacion va)
        {
            await _context.VoluntarioAsociacion.AddAsync(va);
            _context.SaveChanges();
        }

        public async Task<VoluntarioAsociacion> Get(int id)
        {
            var va = await _context.VoluntarioAsociacion.FindAsync(id);
            return va;
        }

        public VoluntarioAsociacion Get(string correo)
        {
            var va = _context.VoluntarioAsociacion.FirstOrDefault(x=>x.Email.Equals(correo));
            return va;
        }

        public async Task<List<VoluntarioAsociacion>> List()
        {
            var va = await _context.VoluntarioAsociacion.ToListAsync();
            return va;
        }

        public async Task<VoluntarioAsociacion> Update(VoluntarioAsociacion va)
        {
            _context.VoluntarioAsociacion.Update(va);
            _context.SaveChanges();
            return va;
        }
    }
}

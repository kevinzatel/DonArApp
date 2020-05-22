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
    public class PacienteService : IPacienteService
    {
        private readonly DataContext _context;

        public PacienteService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> List()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            return pacientes;
        }

        public async Task<Paciente> Get(int id)
        {
            var pacientes = await _context.Pacientes.FindAsync(id);
            return pacientes;
        }

        public async Task Add(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            _context.SaveChanges();
        }
    }
}

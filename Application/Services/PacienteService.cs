using Application.Dto;
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

        public async Task<List<PacienteDto>> ObtenerPacientesDto()
        {
            var pacientesDto = new List<PacienteDto>();
            var pacientes = await List();
            foreach (var paciente in pacientes)
            {
                var pacienteDto = new PacienteDto()
                {
                    Id = paciente.Id,
                    Nombre = paciente.Nombre,
                    Apellido = paciente.Apellido
                };
                pacientesDto.Add(pacienteDto);
            }

            return pacientesDto;
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

        public Paciente Get(string correo) 
        {
            var paciente = _context.Pacientes.FirstOrDefault(x=>x.Email.Equals(correo));
            return paciente;
        }

        public async Task<Paciente> Update(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
            return paciente;
        }

    }
}

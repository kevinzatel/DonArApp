using Application.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public interface IPacienteService
    {
        Task<List<Paciente>> List();
        Task<List<PacienteDto>> ObtenerPacientesDto();
        Task<Paciente> Get(int id);
        Paciente Get(string correo);
        Task Add(Paciente paciente);
        Task<Paciente> Update(Paciente paciente);
    }
}

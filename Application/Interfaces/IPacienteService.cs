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
        Task<Paciente> Get(int id);
        Task Add(Paciente paciente);
    }
}

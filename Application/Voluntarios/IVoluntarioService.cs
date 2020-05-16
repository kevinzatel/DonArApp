using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public interface IVoluntarioService
    {
        Task<List<Voluntario>> GetVoluntarios();
        Task<Voluntario> GetVoluntario(int id);
        Task AddVoluntario(Voluntario voluntario);
        Task AddVoluntarioMedico(VoluntarioMedico voluntarioMedico);
    }
}

using Domain;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public interface IVoluntarioMedicoService
    {
        Task<List<VoluntarioMedico>> List();
        Task<VoluntarioMedico> Get(int id);
        Task Add(VoluntarioMedico voluntarioMedico);
        Task<int> ObtenerMedicoDisponible(EspecialidadEnum? especialidad);
    }
}

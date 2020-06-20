using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public interface IReporteService
    {
        Task<ReporteVoluntarios> GetReporteVoluntarios();
        Task<int[]> GetReporteRangoEtario();
        
    }
}

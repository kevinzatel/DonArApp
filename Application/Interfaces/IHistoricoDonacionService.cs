using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHistoricoDonacionService
    {

        Task<List<HistoricoDonacion>> List();
        Task<HistoricoDonacion> Get(int id);
        Task<List<HistoricoDonacion>> ListDonacionesByUserId(int id);
        Task Add(HistoricoDonacion historicoDonacion);
    }
}

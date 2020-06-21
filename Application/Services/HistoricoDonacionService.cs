using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HistoricoDonacionService : IHistoricoDonacionService
    {
        private readonly DataContext _context;
        public HistoricoDonacionService(DataContext context)
        {
            _context = context;
        }
        public async Task Add(HistoricoDonacion historicoDonacion)
        {
            await _context.HistoricoDonaciones.AddAsync(historicoDonacion);
            _context.SaveChanges();
        }

        public Task<HistoricoDonacion> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<HistoricoDonacion>> List()
        {
            throw new NotImplementedException();
        }

        public Task<List<HistoricoDonacion>> ListDonacionesByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

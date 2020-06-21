using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Voluntarios
{
    public class DonacionService : IDonacionService
    {
        private readonly DataContext _context;
        

        public DonacionService(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Donacion donacion)
        {
            await _context.Donaciones.AddAsync(donacion);
            _context.SaveChanges();
            
            HistoricoDonacion historicoDonacion = new HistoricoDonacion
            {
                IdDonacion = donacion.Id,
                Detalle = donacion.Detalle,
                Cantidad = donacion.Cantidad,
                Destino = donacion.Destino,
                FechaVencimiento = donacion.FechaVencimiento,
                IdUsuario = donacion.IdUsuario,
                Estado = donacion.Estado,
                Fecha = DateTime.Now
            };

            await _context.HistoricoDonaciones.AddAsync(historicoDonacion);
            _context.SaveChanges();
        }


        public async Task<Donacion> Get(int id)
        {
            var donaciones = await _context.Donaciones.FindAsync(id);
            return donaciones;
        }



        public async Task<List<Donacion>> List()
        {
            var donaciones = await _context.Donaciones.ToListAsync();
            return donaciones;
        }

        public async Task<List<Donacion>> ListDonacionesByUserId(int id)
        {
            var donaciones = await _context.Donaciones.Where(d => d.IdUsuario == id).ToListAsync();
            return donaciones;
        }

        public async Task<List<HistoricoDonacion>> ListHistoricoDonacionById(int id)
        {
            var historicoDonacion = await _context.HistoricoDonaciones.Where(d => d.IdDonacion == id).ToListAsync();
            return historicoDonacion;
        }
        public async Task<Donacion> Update(Donacion donacion)
        {
            _context.Donaciones.Update(donacion);
            _context.SaveChanges();

            HistoricoDonacion historicoDonacion = new HistoricoDonacion
            {
                IdDonacion = donacion.Id,
                Detalle = donacion.Detalle,
                Cantidad = donacion.Cantidad,
                Destino = donacion.Destino,
                FechaVencimiento = donacion.FechaVencimiento,
                IdUsuario = donacion.IdUsuario,
                Estado = donacion.Estado,
                Fecha = DateTime.Now
            };

            await _context.HistoricoDonaciones.AddAsync(historicoDonacion);
            _context.SaveChanges();
            return donacion;
        }

    }
}

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
    public class HandlerService //: IHandlerService
    {
        private readonly DataContext _context;
        private readonly IVoluntarioBasicoService _voluntarioBasicoService;

        public HandlerService(DataContext context, IVoluntarioBasicoService voluntarioBasicoService)
        {
            _context = context;
            _voluntarioBasicoService = voluntarioBasicoService;
        }

        //public async Task AsignarVoluntarioBasico(Evento evento)
        //{
        //    _voluntarioBasicoService.List();
        //}
    }
}

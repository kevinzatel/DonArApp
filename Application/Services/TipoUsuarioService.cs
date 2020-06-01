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
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly DataContext _context;

        public TipoUsuarioService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<TipoUsuario>> List()
        {
            var tiposUsuarios = await _context.TiposUsuarios.ToListAsync();
            return tiposUsuarios;
        }
    }
}

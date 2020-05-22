using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<VoluntarioBasico> VoluntariosBasicos { get; set; }
        public DbSet<VoluntarioMedico> VoluntariosMedicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
    }
}

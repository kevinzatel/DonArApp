using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VoluntarioBasico> VoluntariosBasicos { get; set; }
        public DbSet<VoluntarioMedico> VoluntariosMedicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Nacionalidad> Nacionalidades { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<VoluntarioAsociacion> VoluntarioAsociacion { get; set; }
        public DbSet<Donacion> Donaciones { get; set; }

    }
}

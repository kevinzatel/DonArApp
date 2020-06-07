using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.VoluntariosBasicos.Any())
            {
                var voluntariosBasicos = new List<VoluntarioBasico>
                {
                    new VoluntarioBasico
                    {
                        Nombre = "Charly",
                        Apellido = "Mendez",
                        Edad = 20,
                        Genero = GeneroEnum.Masculino,
                        NacionalidadId = 1,
                        TipoUsuarioId = 2,
                        TerminosyCondiciones = true,
                        Dni = 38888888,
                        Telefono = "4444-4444",
                        Email = "charly.magico@gmail.com",
                        Eventos = new List<Evento>()
                    },
                     new VoluntarioBasico
                    {
                        Nombre = "Jimmy",
                        Apellido = "Newtron",
                        Edad = 12,
                        Genero = GeneroEnum.Masculino,
                        NacionalidadId = 1,
                        TipoUsuarioId = 2,
                        TerminosyCondiciones = true,
                        Dni = 39999999,
                        Telefono = "5555-5555",
                        Email = "elcabezon@gmail.com",
                        Eventos = new List<Evento>()
                    },
                      new VoluntarioBasico
                    {
                        Nombre = "Saul",
                        Apellido = "Goodman",
                        Edad = 58,
                        Genero = GeneroEnum.Masculino,
                        NacionalidadId = 1,
                        TipoUsuarioId = 2,
                        TerminosyCondiciones = true,
                        Dni = 39999999,
                        Telefono = "5555-5555",
                        Email = "bettercallsaul@gmail.com",
                        Eventos = new List<Evento>()
                    }
                };

                context.VoluntariosBasicos.AddRange(voluntariosBasicos);
                context.SaveChanges();
            }

            if (!context.VoluntariosMedicos.Any())
            {
                var voluntariosMedicos = new List<VoluntarioMedico>
                {
                    new VoluntarioMedico
                    {
                        Nombre = "Johnny",
                        Apellido = "Bravo",
                        Edad = 18,
                        Genero = GeneroEnum.Masculino,
                        NacionalidadId = 1,
                        TipoUsuarioId = 3,
                        TerminosyCondiciones = true,
                        Dni = 40000000,
                        Telefono = "6666-6666",
                        Email = "holanena@gmail.com",
                        Matricula = "1234",
                        Seguro = "5678",
                        EspecialidadId = 1,
                        InicioJornada = "9:00:00",
                        FinJornada = "13:00:00",
                        Eventos = new List<Evento>()
                    },
                     new VoluntarioMedico
                    {
                        Nombre = "Oscar",
                        Apellido = "Wilde",
                        Edad = 48,
                        Genero = GeneroEnum.Masculino,
                        NacionalidadId = 2,
                        TipoUsuarioId = 3,
                        TerminosyCondiciones = true,
                        Dni = 41111111,
                        Telefono = "7777-7777",
                        Email = "laboratorios.dex@gmail.com",
                        Matricula = "4321",
                        Seguro = "8765",
                        EspecialidadId = 2,
                        InicioJornada = "13:00:00",
                        FinJornada = "19:00:00",
                        Eventos = new List<Evento>()
                    },
                    new VoluntarioMedico
                    {
                        Nombre = "Aldo",
                        Apellido = "Pelegrini",
                        Edad = 48,
                        Genero = GeneroEnum.Masculino,
                        NacionalidadId = 2,
                        TipoUsuarioId = 3,
                        TerminosyCondiciones = true,
                        Dni = 41111111,
                        Telefono = "7777-7777",
                        Email = "teatrodelainesatablerealidad@gmail.com",
                        Matricula = "4444",
                        Seguro = "8888",
                        EspecialidadId = 2,
                        InicioJornada = "13:00:00",
                        FinJornada = "19:00:00",
                        Eventos = new List<Evento>()
                    }
                };

                context.VoluntariosMedicos.AddRange(voluntariosMedicos);
                context.SaveChanges();
            }

            if (!context.Pacientes.Any())
            {
                var pacientes = new List<Paciente>
                    {
                        new Paciente
                        {
                            Nombre = "Charles",
                            Apellido = "Bodeler",
                            Genero = GeneroEnum.Masculino,
                            Dni = 42222222,
                            Telefono = "8888-8888",
                            Email = "la.moneda.falsa@gmail.com",
                            Edad = 28,
                            NacionalidadId = 1,
                            TerminosyCondiciones = true,
                            TipoUsuarioId = 1,
                            HistorialClinico = "historial clinico"
                            
                        }
                    };
                context.Pacientes.AddRange(pacientes);
                context.SaveChanges();
            }

            if (!context.TiposUsuarios.Any())
            {
                var tiposUsuarios = new List<TipoUsuario>
                    {
                        new TipoUsuario
                        {
                            Id= 1,
                            Nombre = "Paciente"
                        },
                        new TipoUsuario
                        {
                            Id= 2,
                            Nombre = "Voluntario Basico"
                        },
                        new TipoUsuario
                        {
                            Id= 3,
                            Nombre = "Voluntario Medico"
                        },
                        new TipoUsuario
                        {
                            Id= 4,
                            Nombre = "Voluntario Asociacion"
                        },
                    };
                context.TiposUsuarios.AddRange(tiposUsuarios);
                context.SaveChanges();
            }

            if (!context.Especialidades.Any())
            {
                var especialidades = new List<Especialidad>
                    {
                        new Especialidad
                        {
                            Nombre = "ATENCION PRIMARIA"
                        },
                        new Especialidad
                        {
                            Nombre = "CARDIOLOGIA"
                        },
                        new Especialidad
                        {
                            Nombre = "CIRUGÍA"
                        },
                        new Especialidad
                        {
                            Nombre = "CLÍNICA"
                        },
                    };
                context.Especialidades.AddRange(especialidades);
                context.SaveChanges();
            }

            if (!context.Nacionalidades.Any())
            {
                var nacionalidades = new List<Nacionalidad>
                    {
                        new Nacionalidad
                        {
                            Nombre = "Argentina"
                        },
                        new Nacionalidad
                        {
                            Nombre = "Holanda"
                        },
                        new Nacionalidad
                        {
                            Nombre = "Turquia"
                        },
                        new Nacionalidad
                        {
                            Nombre = "Nigeria"
                        },
                    };
                context.Nacionalidades.AddRange(nacionalidades);
                context.SaveChanges();
            }

            if (!context.Provincias.Any())
            {
                var provincias = new List<Provincia>
                    {
                        new Provincia
                        {
                            Nombre = "Buenos Aires"
                        },
                        new Provincia
                        {
                            Nombre = "Chaco"
                        },
                        new Provincia
                        {
                            Nombre = "Misiones"
                        },
                        new Provincia
                        {
                            Nombre = "Tucuman"
                        },
                    };
                context.Provincias.AddRange(provincias);
                context.SaveChanges();
            }

            if (!context.Eventos.Any())
            {
                var eventos = new List<Evento>
                    {
                        new Evento
                        {
                            PacienteId = 1,
                            Estado = EstadoEventoEnum.PENDIENTE,
                            Fecha = "1/1/2020",
                            Sintomas = "unos sintomas",
                            VoluntarioBasicoId = 1
                        }
                    };
                context.Eventos.AddRange(eventos);
                context.SaveChanges();
            }

        }
    }
}

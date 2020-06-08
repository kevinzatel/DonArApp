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
                        IdGoogle="",
                        Nombre = "Charly",
                        Apellido = "Mendez",
                        TipoUsuarioId = 2,
                        Email = "charly.magico@gmail.com",
                        Genero = GeneroEnum.Masculino,
                         Dni = 38888888,
                          Telefono = "4444-4444",
                        Edad = 20,
                        NacionalidadId = 1,
                        ProvinciaId=1,
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
                        IdGoogle="",
                        Nombre = "Johnny",
                        Apellido = "Bravo",
                        TipoUsuarioId = 3,
                         Email = "holanena@gmail.com",
                          Genero = GeneroEnum.Masculino,
                          Dni = 40000000,
                           Telefono = "6666-6666",
                        Edad = 18,
                        NacionalidadId = 1,
                        ProvinciaId = 1,
                          EspecialidadId = 1,
                          Matricula = "1234",
                          Seguro = "5678",
                        InicioJornada = "9:00:00",
                        FinJornada = "13:00:00",
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
                            IdGoogle = null,
                            Nombre = "Roni",
                            Apellido = "JL",
                            TipoUsuarioId = 1,
                            Email = "juventud1@live.com.ar",
                            Genero = GeneroEnum.Masculino,
                            Dni = 42222222,
                            Telefono = "8888-8888",
                            Edad = 28,
                            NacionalidadId = 1,
                            ProvinciaId = 1,
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

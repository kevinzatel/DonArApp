using Domain;
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
                        Usuario = "charly",
                        Contrasena = "1234",
                        Nombre = "Charly Mendez ",
                        Dni = 38888888,
                        Telefono = "4444-4444",
                        Email = "charly.magico@gmail.com",
                        Tarea = Domain.Enums.TareaEnum.Acompanamiento
                    },
                     new VoluntarioBasico
                    {
                        Usuario = "jimmy",
                        Contrasena = "1234",
                        Nombre = "Jimmy Newtron",
                        Dni = 39999999,
                        Telefono = "5555-5555",
                        Email = "elcabezon@gmail.com",
                        Tarea = Domain.Enums.TareaEnum.Derivacion
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
                        Usuario = "johnny",
                        Contrasena = "1234",
                        Nombre = "Johnny Bravo",
                        Dni = 40000000,
                        Telefono = "6666-6666",
                        Email = "holanena@gmail.com",
                        Matricula = "1234",
                        Seguro = "5678",
                        Especialidad = Domain.Enums.EspecialidadEnum.Especialidad1,
                        InicioJornada = 9,
                        FinJornada = 13
                    },
                     new VoluntarioMedico
                    {
                        Usuario = "dexter",
                        Contrasena = "1234",
                        Nombre = "Dexter",
                        Dni = 41111111,
                        Telefono = "7777-7777",
                        Email = "laboratorios.dex@gmail.com",
                        Matricula = "4321",
                        Seguro = "8765",
                        Especialidad = Domain.Enums.EspecialidadEnum.Especialidad2,
                        InicioJornada = 15,
                        FinJornada = 19
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
                            Usuario = "un paciente",
                            Contrasena = "1234",
                            Nombre = "Bodeler",
                            Dni = 42222222,
                            Telefono = "8888-8888",
                            Email = "la.moneda.falsa@gmail.com",
                            Edad = 28,
                            Sintomas = "Depresion y delirios"
                        }
                    };
                context.Pacientes.AddRange(pacientes);
                context.SaveChanges();
            }

        }
    }
}

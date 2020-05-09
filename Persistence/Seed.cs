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
            if (!context.Voluntarios.Any())
            {
                var voluntarios = new List<Voluntario>
                {
                    new Voluntario
                    {
                        Name = "Charly Mendez "
                    },
                     new Voluntario
                    {
                        Name = "Jimmy Newtron"
                    }
                };

                context.Voluntarios.AddRange(voluntarios);
                context.SaveChanges();
            }

        }
    }
}

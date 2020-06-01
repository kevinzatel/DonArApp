using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Voluntario : User
    {
        public ICollection<Evento> Eventos { get; set; }
    }
}

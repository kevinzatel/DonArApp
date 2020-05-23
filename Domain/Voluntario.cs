using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Voluntario : User
    {
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public ICollection<Evento> Eventos { get; set; }
    }
}

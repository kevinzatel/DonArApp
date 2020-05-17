using System;

namespace Domain
{
    public abstract class Voluntario : User
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}

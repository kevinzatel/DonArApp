using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Paciente : User
    {
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public string Sintomas {get;set;}
    }
}

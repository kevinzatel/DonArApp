using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class VoluntarioMedico : Voluntario
    {
        public string Matricula { get; set; }
        public string Seguro { get; set; }
    }
}

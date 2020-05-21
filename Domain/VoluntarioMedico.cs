using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class VoluntarioMedico : Voluntario
    {
        public EspecialidadEnum Especialidad { get; set; }
        public string Matricula { get; set; }
        public string Seguro { get; set; }
        public int InicioJornada { get; set; }
        public int FinJornada { get; set; }
    }
}

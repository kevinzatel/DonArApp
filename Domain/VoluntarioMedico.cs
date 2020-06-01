using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class VoluntarioMedico : Voluntario
    {
        public virtual int EspecialidadId { get; set; }
        public string Matricula { get; set; }
        public string Seguro { get; set; }
        public string InicioJornada { get; set; }
        public string FinJornada { get; set; }
    }
}

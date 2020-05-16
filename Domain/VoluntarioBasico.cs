using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class VoluntarioBasico : Voluntario
    {
        public TareaEnum Tarea { get; set; }
    }
}

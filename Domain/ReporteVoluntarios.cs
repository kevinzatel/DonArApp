using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class ReporteVoluntarios
    {
        public int CantVoluntariosBasicos { get; set; }
        public int CantVoluntariosMedicos { get; set; }
        public int CantVoluntariosAsociacion { get; set; }
        public Dictionary<string, int> MedicosPorEspecialidad { get; set; }

    }
}

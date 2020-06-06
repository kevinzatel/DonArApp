using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public string NombreMedico { get; set; }
        public string ApellidoMedico { get; set; }
        public string Fecha { get; set; }
    }
}

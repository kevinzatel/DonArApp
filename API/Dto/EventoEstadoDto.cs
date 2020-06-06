using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class EventoEstadoDto
    {
        public int EventoId { get; set; }
        public EstadoEventoEnum Estado { get; set; }
    }
}

using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public virtual int PacienteId { get; set; }
        public EstadoEventoEnum Estado { get; set; }
        public string Sintomas { get; set; }
        public string Fecha { get; set; }
        public virtual int? EspecialidadId { get; set; }
        public virtual int? VoluntarioBasicoId { get; set; }
        public virtual int? VoluntarioMedicoId { get; set; }
        public bool DiagnosticoPresuntivo { get; set; }
        public bool TratamientoFarmacologico { get; set; }
        public string Detalle { get; set; }
    }
}

using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int TipoUsuarioId {get;set;}
        public GeneroEnum Genero{get;set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public int NacionalidadId { get; set; }
        public bool TerminosyCondiciones { get; set; } 
    }
}

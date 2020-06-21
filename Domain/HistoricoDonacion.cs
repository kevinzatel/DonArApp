using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class HistoricoDonacion
    {
        public int Id { get; set; }
        public int IdDonacion { get; set; }
        public String Detalle { get; set; }
        public int Cantidad { get; set; }
        public String FechaVencimiento { get; set; }
        public String Destino { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}

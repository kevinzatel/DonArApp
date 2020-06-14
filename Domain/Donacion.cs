using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Donacion
    {
        public int Id { get; set; }
        public String FechaIngreso { get; set; }
        public String FechaEgreso { get; set; }
        public String Estado { get; set; }
        public int IdDestinatario { get; set; }
        public List<ItemDonacion> Items { get; set; }
    }
}

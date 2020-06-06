using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Donacion
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public List<ItemDonacion> Items { get; set; }
    }
}

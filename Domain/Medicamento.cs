using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Medicamento : ItemDonacion
    {
        public DateTime Vencimiento { get; set; }
        public string Lote { get; set; }

    }
}

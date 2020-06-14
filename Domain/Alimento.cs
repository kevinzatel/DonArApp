using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Alimento : ItemDonacion
    {
        public DateTime Vencimiento { get; set; }
    }
}

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Donacion
    {
        public int Id { get; set; }
        public String Detalle { get; set; }
        public int Cantidad { get; set; }
        public String FechaVencimiento { get; set; }
        public String Destino { get; set; }
        public int IdUsuario { get; set; }
    }
}

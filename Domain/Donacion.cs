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
        public string Detalle { get; set; }
        public int Cantidad { get; set; }
        public string FechaVencimiento { get; set; }
        public string Destino { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; }
    }
}

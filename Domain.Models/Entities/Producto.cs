using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Producto
    {
        public int Referencia { get; set; }
        public int Descripcion { get; set; }
        public string FormatoVenta { get; set; }
        public string Marca { get; set; }
        public string Fabrica { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public double IVA { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Producto()
        {

        }

    }
}

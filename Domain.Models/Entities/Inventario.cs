using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Inventario
    {
        private double id { get; set; }
        public int Referencia { get; set; }
        public int Cantidad { get; set; }
        public string Bodega { get; set; }
        public Inventario()
        {

        }
    }
}

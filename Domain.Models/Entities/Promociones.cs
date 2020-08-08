using Domain.Models.Base;
using Domain.Models.Entities.Operacionales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Promociones: Entity<int>
    {
        public double PorcentajeDesc { get; set; }
        public List<PromocionesDFactura> PromocionesDFacturas { get; set; }

    }
}

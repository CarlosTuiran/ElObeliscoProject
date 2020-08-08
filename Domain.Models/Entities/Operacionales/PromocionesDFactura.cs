using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities.Operacionales
{
    public class PromocionesDFactura: Entity<int>
    {
        public int PromocionesId { get; set; }
        public int DFacturaId { get; set; }
    }
}

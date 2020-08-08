using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities.Operacionales
{
    public class ProductoDFactura:Entity<int>
    {
        public int ProductoId { get; set; }
        public int DFacturaId { get; set; }
    }
}

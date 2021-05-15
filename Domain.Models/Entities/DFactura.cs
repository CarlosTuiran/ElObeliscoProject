using Domain.Models.Base;
using Domain.Models.Entities.Operacionales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Domain.Models.Entities
{
    public class DFactura : Entity<int>
    {
        public int MfacturaId { get; set; }
        public string Referencia { get; set; }
        public int? idPromocion { get; set; }
        public string Bodega { get; set; }
        public double Cantidad { get; set; }
        public double CantidadDigitada { get; set; }
        public string FormatoProducto { get; set; }
        public double PrecioUnitario { get; set; }
        public double IVA { get; set; }
        public double PrecioTotal { get; set; }
        public DateTime FechaFactura { get; set; }
        public List<ProductoDFactura> ProductoDFacturas { get; set; }
        public List<PromocionesDFactura> PromocionesDFacturas { get; set; }

        public DFactura(){}

        public DFactura(int mfacturaId, string referencia, int? idPromocion, string bodega, string formatoProducto,
                        double cantidad, double cantidadDigitada, double precioUnitario, double iVA, double precioTotal, 
                        DateTime fechaFactura)
        {
            MfacturaId = mfacturaId;
            Referencia = referencia;
            this.idPromocion = idPromocion;
            Bodega = bodega;
            FormatoProducto = formatoProducto;
            Cantidad = cantidad;
            CantidadDigitada = cantidadDigitada;
            PrecioUnitario = precioUnitario;
            IVA = iVA;
            PrecioTotal = precioTotal;
            FechaFactura = fechaFactura;
        }

        public IReadOnlyList<string> CanCrear(DFactura dFactura)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(dFactura.Referencia))
                errors.Add("Campo Referencia vacio");
            if (string.IsNullOrEmpty(dFactura.Bodega))
                errors.Add("Campo Bodega vacio");
            if (dFactura.Cantidad == 0)
                errors.Add("Campo Cantidad vacio");
            if (dFactura.CantidadDigitada == 0)
                errors.Add("Campo Cantidad Digitada vacio");
            if (dFactura.PrecioUnitario == 0)
                errors.Add("Campo Precio Unitario vacio");
            //if (!this.FechaFactura.HasValue) Nunca sera vacio el Default es 0
            //    errors.Add("Campo Fecha Factura vacio");
            if (dFactura.PrecioTotal == 0)
                errors.Add("Campo Precio Total vacio");
            return errors;
        }
    }
}

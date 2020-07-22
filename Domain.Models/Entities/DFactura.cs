using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class DFactura
    {
        public int idDFactura { get; set; }
        public int idMfactura { get; set; }
        public int Referencia { get; set; }
        public int idPromocion { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get; set; }

        public DFactura(int idDFactura, int idMfactura, int referencia, int idPromocion, double cantidad, double precioUnitario, double precioTotal)
        {
            this.idDFactura = idDFactura;
            this.idMfactura = idMfactura;
            Referencia = referencia;
            this.idPromocion = idPromocion;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            PrecioTotal = precioTotal;
        }

        public IReadOnlyList<string> CanCrear(DFactura dFactura)
        {
            var errors = new List<string>();
            if (this.Cantidad == 0)
                errors.Add("Campo Cantidad vacio");
            if (this.PrecioUnitario == 0)
                errors.Add("Campo Precio Unitario vacio");
            if (this.PrecioTotal == 0)
                errors.Add("Campo Precio Total vacio");
            return errors;
        }
    }
}

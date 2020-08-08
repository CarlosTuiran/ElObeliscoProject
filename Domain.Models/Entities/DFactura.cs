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
        public int idDFactura { get; set; }
        public int MfacturaId { get; set; }
        public string Referencia { get; set; }
        public int idPromocion { get; set; }
        public string Bodega { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get; set; }
        public DateTime FechaFactura { get; set; }
        public List<ProductoDFactura> ProductoDFacturas { get; set; }
        public List<PromocionesDFactura> PromocionesDFacturas { get; set; }

        public DFactura(int idDFactura, int idMfactura, string referencia, int idPromocion, string bodega, int cantidad, double precioUnitario)
        {
            this.idDFactura = idDFactura;
            this.MfacturaId = idMfactura;
            Referencia = referencia;
            this.idPromocion = idPromocion;
            this.Bodega = bodega;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            PrecioTotal = CalcularPrecioTotal();
            FechaFactura = DateTime.Today;
        }

        public IReadOnlyList<string> CanCrear(DFactura dFactura)
        {
            var errors = new List<string>();
            if (this.Cantidad == 0)
                errors.Add("Campo Cantidad vacio");
            if (this.PrecioUnitario == 0)
                errors.Add("Campo Precio Unitario vacio");
            /*if (this.PrecioTotal == 0)
                errors.Add("Campo Precio Total vacio");*/
            return errors;
        }

        public double CalcularPrecioTotal()
        {
            double precioTotal= this.Cantidad * this.PrecioUnitario; //CUANDO SE DEFINAN LAS PROMOCIONES ACA TOCA AÑADIRLO
            return precioTotal;
        }
    }
}

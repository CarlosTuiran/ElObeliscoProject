﻿using Domain.Models.Base;
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
        public int? idPromocion { get; set; }
        public string Bodega { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get=> this.Cantidad * this.PrecioUnitario;}//CUANDO SE DEFINAN LAS PROMOCIONES ACA TOCA AÑADIRLO
        public int FechaFactura { get; set; }
        public List<ProductoDFactura> ProductoDFacturas { get; set; }
        public List<PromocionesDFactura> PromocionesDFacturas { get; set; }

        public DFactura(){}
        public DFactura(int idDFactura, int idMfactura, string referencia, int idpromocion, string bodega, int cantidad, double precioUnitario, int fechaFactura)
        {
            this.idDFactura = idDFactura;
            this.MfacturaId = idMfactura;
            Referencia = referencia;
            idPromocion = idpromocion;
            this.Bodega = bodega;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
           // PrecioTotal = CalcularPrecioTotal();
            FechaFactura = fechaFactura;
        }

        public IReadOnlyList<string> CanCrear(DFactura dFactura)
        {
            var errors = new List<string>();
            if (this.idDFactura == 0)
                errors.Add("Campo Cantidad vacio");
            if (string.IsNullOrEmpty(this.Referencia))
                errors.Add("Campo Cantidad vacio");
            if (string.IsNullOrEmpty(this.Bodega))
                errors.Add("Campo Cantidad vacio");
            if (this.Cantidad == 0)
                errors.Add("Campo Cantidad vacio");
            if (this.PrecioUnitario == 0)
                errors.Add("Campo Precio Unitario vacio");
            //if (!this.FechaFactura.HasValue) Nunca sera vacio el Default es 0
            //    errors.Add("Campo Fecha Factura vacio");
            /*if (this.PrecioTotal == 0)
                errors.Add("Campo Precio Total vacio");*/
            return errors;
        }

        /*public double CalcularPrecioTotal()
        {
            double precioTotal= this.Cantidad * this.PrecioUnitario; //CUANDO SE DEFINAN LAS PROMOCIONES ACA TOCA AÑADIRLO
            return precioTotal;
        }*/
    }
}

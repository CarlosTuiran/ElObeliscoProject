﻿using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Domain.Models.Base.BaseEntity;

namespace Domain.Models.Entities
{
    public class DFactura : Entity<int>
    {
        public int idDFactura { get; set; }
        public int idMfactura { get; set; }
        public string Referencia { get; set; }
        public int idPromocion { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get; set; }
        public DateTime FechaFactura { get; set; }

        public DFactura(int idDFactura, int idMfactura, string referencia, int idPromocion, double cantidad, double precioUnitario, double precioTotal)
        {
            this.idDFactura = idDFactura;
            this.idMfactura = idMfactura;
            Referencia = referencia;
            this.idPromocion = idPromocion;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            PrecioTotal = precioTotal;
            FechaFactura = DateTime.Today;
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

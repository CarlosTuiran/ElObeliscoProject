﻿using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Models.Entities
{
    public class MFactura : Entity<int>
    {
        public int idMfactura { get; set; }
        public int EmpleadoId { get; set; }
        public int TercerosId { get; set; }
        public int TipoMovimientoId { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaPago { get; set; }
        public double SubTotal { get; set; }
        public double ValorDevolucion { get; set; }
        public double Descuento { get; set; }
        public double IVA { get; set; }
        public double Total { get=> SubTotal-(SubTotal*Descuento)+(SubTotal*IVA); }
        public double Abono { get; set; }
        public string EstadoFactura { get; set; }
        public List<DFactura> DFacturas { get; set; }
        

        public MFactura(int idMfactura, int idEmpleado, int nit, int idMovimiento, string tipoMovimiento, DateTime fechaFactura, 
            DateTime fechaPago, double subTotal, double valorDevolucion, double descuento, double iVA, /*double total,*/ double abono, string estadoFactura)
        {
            this.idMfactura = idMfactura;
            this.EmpleadoId = idEmpleado;
            TercerosId = nit;
            this.TipoMovimientoId = idMovimiento;
            TipoMovimiento = tipoMovimiento;
            FechaFactura = fechaFactura;
            FechaPago = fechaPago;
            SubTotal = subTotal;
            ValorDevolucion = valorDevolucion;
            Descuento = descuento;
            IVA = iVA;
            /*Total = total;*/
            Abono = abono;
            EstadoFactura = estadoFactura;
        }

        public IReadOnlyList<string> CanCrear(MFactura mFactura)
        {
            var errors = new List<string>();
            if (this.FechaFactura == null)
                errors.Add("Campo Fecha Factura vacio");
            if (this.FechaPago == null)
                errors.Add("Campo Fecha Pago vacio");
            if (this.ValorDevolucion < 0)
                errors.Add("Campo Valor Devolucion Erroneo");
            if (this.Abono < 0)
                errors.Add("Campo Abonor Erroneo");
            return errors;
        }


    }
}

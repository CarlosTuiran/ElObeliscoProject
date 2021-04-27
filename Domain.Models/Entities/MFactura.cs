using Domain.Models.Base;
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
        public DateTime? FechaPago { get; set; }
        public double SubTotal { get; set; }
        public double ValorDevolucion { get; set; }
        public double Descuento { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }
        public double Abono { get; set; }
        public string EstadoFactura { get; set; }
        public List<DFactura> DFacturas { get; set; }

        public MFactura()
        {
        }


        public MFactura(int idMfactura, int idEmpleado, int nit, int idMovimiento, string tipoMovimiento, DateTime fechaFactura, DateTime? fechaPago,
            double subTotal, double valorDevolucion, double descuento, double iVA, /*double total,*/ double abono)
        {
            this.idMfactura = idMfactura;
            this.EmpleadoId = idEmpleado;
            TercerosId = nit;
            this.TipoMovimientoId = idMovimiento;
            TipoMovimiento = tipoMovimiento;
            FechaFactura = fechaFactura;
            this.FechaPago = fechaPago;
            SubTotal = subTotal;
            ValorDevolucion = valorDevolucion;
            Descuento = descuento;
            IVA = iVA;
            Abono = abono;
            EstadoFactura = this.FechaPago==null?"Pendiente":"Pagado";
            CalcularTotal();
        }

        public IReadOnlyList<string> CanCrear(MFactura mFactura)
        {
            var errors = new List<string>();
            if (this.idMfactura == 0)
                errors.Add("Campo identificacion factura maestra vacio");
            if (this.EmpleadoId == 0)
                errors.Add("Campo identificacion empleado vacio");
            if (this.TercerosId == 0)
                errors.Add("Campo identificacion tercero vacio");
            if (this.TipoMovimientoId == 0)
                errors.Add("Campo identificacion tipo movimiento vacio");
            if (this.SubTotal == 0)
                errors.Add("Campo Sub total vacio");
            if (this.SubTotal < 0)
                errors.Add("Campo Sub total erroneo");
            if (this.ValorDevolucion < 0)
                errors.Add("Campo Valor devolucion vacio");
            //if (!this.FechaFactura.HasValue) Nunca sera Vacio el default es 0
            //    errors.Add("Campo Fecha Factura vacio");
            if (this.Descuento < 0)
                errors.Add("Campo Descuento erroneo");
            if (this.IVA < 0)
                errors.Add("Campo IVA erroneo");
            //if (!this.FechaPago.HasValue) Puede Crearse sin alguna fecha de Pago
            //    errors.Add("Campo Fecha Pago vacio");
            if (this.ValorDevolucion < 0)
                errors.Add("Campo Valor Devolucion Erroneo");
            if (this.Abono < 0)
                errors.Add("Campo Abonor Erroneo");
          
            return errors;
        }

        public void CalcularTotal() 
        {
            this.Total = this.SubTotal - (this.SubTotal * this.Descuento) + (this.SubTotal * this.IVA);
        }

    }
}

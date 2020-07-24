using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Base.BaseEntity;

namespace Domain.Models.Entities
{
    public class MFactura : Entity<int>
    {
        public int idMfactura { get; set; }
        public int idEmpleado { get; set; }
        public int Nit { get; set; }
        public int idMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaPago { get; set; }
        public double SubTotal { get; set; }
        public double ValorDevolucion { get; set; }
        public double Descuento { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }
        public double Abono { get; set; }
        public string EstadoFactura { get; set; }

        public MFactura(int idMfactura, int idEmpleado, int nit, int idMovimiento, string tipoMovimiento, DateTime fechaFactura, 
            DateTime fechaPago, double subTotal, double valorDevolucion, double descuento, double iVA, double total, double abono, string estadoFactura)
        {
            this.idMfactura = idMfactura;
            this.idEmpleado = idEmpleado;
            Nit = nit;
            this.idMovimiento = idMovimiento;
            TipoMovimiento = tipoMovimiento;
            FechaFactura = fechaFactura;
            FechaPago = fechaPago;
            SubTotal = subTotal;
            ValorDevolucion = valorDevolucion;
            Descuento = descuento;
            IVA = iVA;
            Total = total;
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

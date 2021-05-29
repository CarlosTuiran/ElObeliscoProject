using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Aplicacion.Request
{
    public class CrearMFacturaRequest
    {
        public int Id { get; set; }
        public int idMfactura { get; set; } 
        public int EmpleadoId { get; set; }
        public int TercerosId { get; set; }
        public int TipoMovimientoId { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaFactura { get => DateTime.Now; }
        public DateTime? FechaPago { get; set; }
        public double SubTotal { get; set; }
        public double ValorDevolucion { get; set; }
        public double Descuento { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }
        public double Abono { get; set; }
        public string Serial { get; set; }
        public string Observaciones { get; set; }
        
        
        
        public List<CrearDFacturaRequest> DFacturas { get; set; }
        

    }
    public class CrearMFacturaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Factura Creada Exitosamente");
        }
        
    }
}
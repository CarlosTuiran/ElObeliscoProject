using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearDFacturaRequest
    {
        public int idDFactura { get; set; }
        public int MfacturaId { get; set; }
        public string Referencia { get; set; }
        public int PromocionId { get; set; }
        public string Bodega { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public DateTime FechaFactura { get => DateTime.Now; }

        

    }
    public class CrearDFacturaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Detalles de Factura Creado Exitosamente");
        }
    }
}

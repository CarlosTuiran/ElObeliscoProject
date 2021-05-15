using System.Collections.Generic;

namespace Aplicacion.Request.Salidas
{
    public class ConsultarFacturaCompraResponse
    {
        public string Nombre { get; set; }
        public string NIT { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string FechaComprobante { get; set; }
        public string FechaVencimiento { get; set; }
        public string ValorBruto { get; set; }
        public string Iva { get; set; }
        public string ValorTotal { get; set; }
        public string CondicionPago { get; set; }
        public string NombreMov { get; set; }
        public string Serial { get; set; }
        public List<DetallesFactura> Dfacturas { get; set; }
    }
    public class DetallesFactura
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public string ValorUnitario { get; set; }
        public double Iva { get; set; }
        public double Cantidad { get; set; }
        public string ValorTotal{ get; set; }
    }

}
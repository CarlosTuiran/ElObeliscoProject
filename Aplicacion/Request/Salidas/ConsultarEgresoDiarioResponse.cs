using System.Collections.Generic;

namespace Aplicacion.Request.Salidas
{
    public class ConsultarEgresoDiarioResponse
    {
        public string Nombre { get; set; }
        public string NIT { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string FechaComprobante { get; set; }
        public string Cheque{get; set;}        
        public string ValorTotal { get; set; }        
        public string NombreMov { get; set; }
        public string Serial { get; set; }
        public string NombreBanco { get; set; }
        public string Observaciones { get; set; }
        
        
        
        public List<DetallesFactura> Dfacturas { get; set; }
    }
    

}
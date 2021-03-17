using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarInventarioRequest
    {
        
        public string Referencia { get; set; }
        public int Cantidad { get; set; }
        public string Bodega { get; set; }  
        public string TipoMovimiento { get; set; }
        
             
    }
    public class ActualizarInventarioResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Inventario actualizado exitosamente");
        }
    }
}

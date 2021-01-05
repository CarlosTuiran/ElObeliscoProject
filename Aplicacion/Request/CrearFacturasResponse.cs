using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearFacturasResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Factura Creada Exitosamente");
        }
    }
}

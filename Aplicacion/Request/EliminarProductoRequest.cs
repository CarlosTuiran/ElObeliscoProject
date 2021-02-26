using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarProductoRequest
    {
        public string Referencia { get; set; }
        public string Estado { get; set; }
    }

    public class EliminarProductoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Producto Eliminado Exitosamente");
        }
    }
}

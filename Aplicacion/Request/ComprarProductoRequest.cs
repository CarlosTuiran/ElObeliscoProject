using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ComprarProductoRequest
    {
        public int idMfactura { get; set; }
        public string TipoMovimiento { get; set; }

    }
    public class ComprarProductoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Compra realizada exitosamente");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarFormatoVentaRequest
    {
    }
    public class EliminarFormatoVentaResponse
    {
        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Formato Eliminado Exitosamente");
        }
    }
}

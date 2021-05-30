using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarParametrosResponse
    {
        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Parametro Eliminado Exitosamente");
        }
    }
}

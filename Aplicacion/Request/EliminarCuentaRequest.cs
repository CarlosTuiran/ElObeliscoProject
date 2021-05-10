using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarCuentaRequest
    {
        public int Id { get; set; }
    }
    public class EliminarCuentaResponse
    {
        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Cuenta Eliminada Exitosamente");
        }
    }
}

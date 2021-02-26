using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarTerceroRequest
    {
        public string Nit { get; set; }
        public string Estado { get; set; }
    }

    public class EliminarTerceroResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Tercero Eliminado Exitosamente");
        }
    }
}

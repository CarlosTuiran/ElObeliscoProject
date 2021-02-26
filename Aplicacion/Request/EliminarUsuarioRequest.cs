using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarUsuarioRequest
    {
        public int EmpleadoId { get; set; }
    }
    public class EliminarUsuarioResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Usuario Eliminado Exitosamente");
        }
    }
}

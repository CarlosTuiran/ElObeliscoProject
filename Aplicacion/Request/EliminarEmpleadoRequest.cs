using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarEmpleadoRequest
    {
        public int IdEmpleado { get; set; }
        public string Estado { get; set; }
    }

    public class EliminarEmpleadoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Empleado Eliminado Exitosamente");
        }
    }
}

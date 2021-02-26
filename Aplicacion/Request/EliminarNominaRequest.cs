using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarNominaRequest
    {
        public string IdNomina { get; set; } 
        public int IdEmpleado { get; set; }
    }
    public class EliminarNominaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Nomina Eliminado Exitosamente");
        }
    }
}

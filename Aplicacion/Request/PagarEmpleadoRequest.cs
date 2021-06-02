using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class PagarEmpleadoRequest
    {
        readonly int Month = DateTime.Now.Month;
        readonly int Year = DateTime.Now.Year;
        public string IdNomina { get => Month + " - " + Year; }
        public int IdEmpleado { get; set; }
    }
    public class PagarEmpleadoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Empleado Pagado Exitosamente");
        }
    }
}

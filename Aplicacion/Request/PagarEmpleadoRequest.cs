using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class PagarEmpleadoRequest
    {
        public int IdLiquidacion { get; set; }
        public int IdNomina { get; set; }
        public double Monto { get; set; }
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

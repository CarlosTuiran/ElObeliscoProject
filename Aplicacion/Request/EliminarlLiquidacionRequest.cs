using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarlLiquidacionRequest
    {
        public string NominaId { get; set; }
        public int IdEmpleado { get; set; }
    }
    public class EliminarLiquidacionResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Liquidacion Eliminado Exitosamente");
        }
    }
}

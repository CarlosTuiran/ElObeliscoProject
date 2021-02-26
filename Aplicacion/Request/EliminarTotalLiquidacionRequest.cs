using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarTotalLiquidacionRequest
    {
        public string NominaId { get; set; }
    }
    public class EliminarTotalLiquidacionResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Total Liquidacion Eliminado Exitosamente");
        }
    }
}

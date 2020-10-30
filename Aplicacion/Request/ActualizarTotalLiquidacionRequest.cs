using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarTotalLiquidacionRequest
    {
        public int IdLiquidacion { get; set; }
        public double ValorTotalNomina { get; set; }
        public double Sena { get; set; }
        public double Icbf { get; set; }
        public double Comfacesar { get; set; }
        public double Total { get; set; }
    }

    public class ActualizarTotalLiquidacionResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Total Liquidacion Actualizado Exitosamente");
        }
    }
}

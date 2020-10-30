using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearTotalLiquidacionRequest
    {
        public int IdLiquidacion { get; set; }
        public double ValorTotalNomina { get; set; }
        public double Sena { get; set; }
        public double Icbf { get; set; }
        public double Comfacesar { get; set; }
        public double Total { get; set; }
    }

    public class CrearTotalLiquidacionResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Total Liquidacion Creado Exitosamente");
        }
    }
}

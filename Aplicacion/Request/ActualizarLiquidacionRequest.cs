using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarLiquidacionRequest
    {
        public string IdLiquidacion { get; set; }
        public string NominaId { get; set; }
        public int IdEmpleado { get; set; }
        public double SueldoOrdinario { get; set; }
        public double SubTransporte { get; set; }
        public double TotalDevengado { get; set; }
        public double Salud { get; set; }
        public double Pension { get; set; }
        public double TotalDeducido { get; set; }
        public double TotalPagar { get; set; }
    }

    public class ActualizarLiquidacionResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Liquidacion Actualizado Exitosamente");
        }
    }
}

using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearTotalLiquidacionRequest
    {
        public string NominaId { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request.Salidas
{
    public class ConsultarLiquidacionResponse
    {
        public string NominaId { get; set; }
        public int IdEmpleado { get; set; }
        public string NombreMov { get; set; }
        public string Serial { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Direccion { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public double SueldoOrdinario { get; set; }
        public double SubTransporte { get; set; }
        public double Comisiones { get; set; }
        public double Salud_Trabajador { get; set; }
        public double Pension_Trabajador { get; set; }
        public double TotalPagar { get; set; }
    }
}

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
        public int DiasTrabajados { get; set; }
        public string Cargo { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Direccion { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public string SueldoOrdinario { get; set; }
        public string SubTransporte { get; set; }
        public string Comisiones { get; set; }
        public string Salud_Trabajador { get; set; }
        public string Pension_Trabajador { get; set; }
        public string TotalDevengos { get; set; }
        public string TotalDeducciones { get; set; }
        public string TotalPagar { get; set; }
    }
}

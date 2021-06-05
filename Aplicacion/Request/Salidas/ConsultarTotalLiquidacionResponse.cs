using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request.Salidas
{
    public class ConsultarTotalLiquidacionResponse
    {
        public int Mes { get; set; }
        public int Anio { get; set; }
        public string ValorTotalNomina { get; set; }
        public string Sueldo { get; set; }
        public string SubTransporte { get; set; }
        public string TotalDevengado { get; set; }
        public string Comisiones { get; set; }
        public string Salud_Empleador { get; set; }
        public string Salud_Trabajador { get; set; }
        public string Salud { get; set; }
        public string Pension_Trabajador { get; set; }
        public string Pension_Empleador { get; set; }
        public string Pension { get; set; }
        public string Prima { get; set; }
        public string Cesantias { get; set; }
        public string Int_Cesantias { get; set; }
        public string Vacaciones { get; set; }
        public string Arl { get; set; }
        public string Caja_Comp { get; set; }
        public string ICBF { get; set; }
        public string SENA { get; set; }
        public string RetencionAporteNomina { get; set; }
        public string AcreedoresVarios { get; set; }
        public string Provision { get; set; }
        public string SalariosPagar { get; set; }
        public string Parafiscales { get; set; }
        public string NominaId { get; set; }
        public string NombreMov { get; set; }
        public string Serial { get; set; }
    }
}

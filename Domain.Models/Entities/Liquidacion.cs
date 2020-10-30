using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Base;

namespace Domain.Models.Entities
{
    public class Liquidacion : Entity<int>
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
        public TotalLiquidacion TotalLiquidacion { get; set; }
        
        public Liquidacion()
        {
                
        }

        public Liquidacion(string idLiquidacion, string nominaId, int idEmpleado, double sueldoOrdinario, double subTransporte, double totalDevengado, double salud, double pension, double totalDeducido, double totalPagar)
        {
            IdLiquidacion = idLiquidacion;
            NominaId = nominaId;
            IdEmpleado = idEmpleado;
            SueldoOrdinario = sueldoOrdinario;
            SubTransporte = subTransporte;
            TotalDevengado = totalDevengado;
            Salud = salud;
            Pension = pension;
            TotalDeducido = totalDeducido;
            TotalPagar = totalPagar;
        }

        public IReadOnlyList<string> CanCrear(Liquidacion liquidacion)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(liquidacion.IdLiquidacion))
                errors.Add("Campo Identificacion Liquidacion vacio");
            if (string.IsNullOrEmpty(liquidacion.NominaId))
                errors.Add("Campo Identificacion Nomina vacio");
            if (liquidacion.IdEmpleado == 0)
                errors.Add("Campo Identificacion Empleado vacio");
            if (liquidacion.SueldoOrdinario == 0)
                errors.Add("Campo Sueldo Ordinario vacio");
            if (liquidacion.SubTransporte == 0)
                errors.Add("Campo Subsidio de Transporte vacio");
            if (liquidacion.TotalDeducido == 0)
                errors.Add("Campo Total Deducido vacio");
            if (liquidacion.TotalDevengado == 0)
                errors.Add("Campo Total Devengado vacio");
            if (liquidacion.Salud == 0)
                errors.Add("Campo Salud vacio");
            if (liquidacion.Pension == 0)
                errors.Add("Campo Pension vacio");
            if (liquidacion.TotalPagar == 0)
                errors.Add("Campo Total a Pagar vacio");

            return errors;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Base;

namespace Domain.Models.Entities
{
    public class Liquidacion : Entity<int>
    {
        public string NominaId { get; set; }
        public int IdEmpleado { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
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

        public Liquidacion(string nominaId, int idEmpleado, int mes, int anio, double sueldoOrdinario, double subTransporte, double totalDevengado, double salud, double pension, double totalDeducido, double totalPagar)
        {
            NominaId = nominaId;
            IdEmpleado = idEmpleado;
            Mes = mes;
            Anio = anio;
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
            if (string.IsNullOrEmpty(liquidacion.NominaId))
                errors.Add("Campo Identificacion Nomina vacio");
            if (liquidacion.IdEmpleado == 0)
                errors.Add("Campo Identificacion Empleado vacio");
            if (liquidacion.SueldoOrdinario == 0)
                errors.Add("Campo Sueldo Ordinario vacio");
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

        public void CalculoLiquidacion(Nomina nomina) 
        {
            int Month = DateTime.Now.Month;
            int Year = DateTime.Now.Year;
            this.NominaId = Month+" - "+Year;
            this.IdEmpleado = nomina.IdEmpleado;
            this.Mes = Month;
            this.Anio = Year;
            this.SueldoOrdinario = nomina.SalarioBase / 30 * nomina.DiasTrabajados;
            this.SubTransporte = nomina.SubTransporte / 30 * nomina.DiasTrabajados;
            double HE = (((nomina.SalarioBase / 30) / 8) * 1.25) * nomina.HorasExtras;
            this.TotalDevengado = this.SueldoOrdinario + this.SubTransporte + HE;
            this.Salud = (this.TotalDevengado - this.SubTransporte) * 0.04;
            this.Pension = (this.TotalDevengado - this.SubTransporte) * 0.04;
            this.TotalDeducido = this.Salud + this.Pension;
            this.TotalPagar = this.TotalDevengado - this.TotalDeducido;
        }

    }
}

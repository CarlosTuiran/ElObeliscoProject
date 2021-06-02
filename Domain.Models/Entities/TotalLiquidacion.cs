using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class TotalLiquidacion : Entity<int>
    {
        public int Mes { get; set; }
        public int Anio { get; set; }
        public double ValorTotalNomina { get; set; }
        public double Sueldo { get; set; }
        public double SubTransporte { get; set; }
        public double TotalDevengado { get; set; }
        public double Comisiones { get; set; }
        public double Salud_Empleador { get; set; }
        public double Salud_Trabajador { get; set; }
        public double Salud { get; set; }
        public double Pension_Trabajador { get; set; }
        public double Pension_Empleador { get; set; }
        public double Pension { get; set; }
        public double Prima { get; set; }
        public double Cesantias { get; set; }
        public double Int_Cesantias { get; set; }
        public double Vacaciones { get; set; }
        public double Arl { get; set; }
        public double Caja_Comp { get; set; }
        public double ICBF { get; set; }
        public double SENA { get; set; }
        public double RetencionAporteNomina { get; set; }
        public double AcreedoresVarios { get; set; }
        public double Provision { get; set; }
        public double SalariosPagar { get; set; }
        public double Parafiscales { get; set; }
        public string NominaId { get; set; }

        public TotalLiquidacion(int mes, int anio, double valorTotalNomina, 
            double sueldo, double subTransporte, double totalDevengado, 
            double salud_Empleador, double salud_Trabajador, double salud, 
            double pension_Trabajador, double pension_Empleador, double pension, 
            double prima, double cesantias, double int_Cesantias, double vacaciones, 
            double arl, double caja_Comp, double iCBF, double sENA, 
            double retencionAporteNomina, double acreedoresVarios, 
            double provision, double salariosPagar, double parafiscales, 
            string nominaId)
        {
            Mes = mes;
            Anio = anio;
            ValorTotalNomina = valorTotalNomina;
            Sueldo = sueldo;
            SubTransporte = subTransporte;
            TotalDevengado = totalDevengado;
            Salud_Empleador = salud_Empleador;
            Salud_Trabajador = salud_Trabajador;
            Salud = salud;
            Pension_Trabajador = pension_Trabajador;
            Pension_Empleador = pension_Empleador;
            Pension = pension;
            Prima = prima;
            Cesantias = cesantias;
            Int_Cesantias = int_Cesantias;
            Vacaciones = vacaciones;
            Arl = arl;
            Caja_Comp = caja_Comp;
            ICBF = iCBF;
            SENA = sENA;
            RetencionAporteNomina = retencionAporteNomina;
            AcreedoresVarios = acreedoresVarios;
            Provision = provision;
            SalariosPagar = salariosPagar;
            Parafiscales = parafiscales;
            NominaId = nominaId;
        }

        public TotalLiquidacion() { }

        public IReadOnlyList<string> CanCrear(TotalLiquidacion totalLiquidacion)
        {
            var errors = new List<string>();
            if (totalLiquidacion.Mes == 0)
                errors.Add("Campo Mes vacio");
            if (totalLiquidacion.Anio == 0)
                errors.Add("Campo Año vacio");
            if (totalLiquidacion.ValorTotalNomina == 0)
                errors.Add("Campo Valor Total de Nomina vacio");
            if (totalLiquidacion.NominaId == null)
                errors.Add("Campo Sena vacio");
            return errors;
        }
        /*
        public void CrearTotalLiquidacion(List<Liquidacion> Liquidaciones) 
        {
            
            foreach (var liquidacion in Liquidaciones)
            {
                this.ValorTotalNomina += liquidacion.TotalPagar;
            }
            this.Sena = this.ValorTotalNomina * 0.02;
            this.Icbf = this.ValorTotalNomina * 0.03;
            this.Comfacesar = this.ValorTotalNomina * 0.04;
            this.Total = this.Sena + this.Icbf + this.Comfacesar;
        }*/
    }
}

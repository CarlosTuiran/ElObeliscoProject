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
        public double Sena { get; set; }
        public double Icbf { get; set; }
        public double Comfacesar { get; set; }
        public double Total { get; set; }
        public string NominaId { get; set; }

        public TotalLiquidacion(int mes, int anio, double valorTotalNomina, double sena, double icbf, double comfacesar, double total, string nominaId)
        {
            Mes = mes;
            Anio = anio;
            ValorTotalNomina = valorTotalNomina;
            Sena = sena;
            Icbf = icbf;
            Comfacesar = comfacesar;
            Total = total;
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
            if (totalLiquidacion.Sena == 0)
                errors.Add("Campo Sena vacio");
            if (totalLiquidacion.Icbf == 0)
                errors.Add("Campo ICBF vacio");
            if (totalLiquidacion.Comfacesar == 0)
                errors.Add("Campo Comfacesar vacio");
            if (totalLiquidacion.Total == 0)
                errors.Add("Campo Total vacio");

            return errors;
        }

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
        }
    }
}

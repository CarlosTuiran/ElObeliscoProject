using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class TotalLiquidacion : Entity<int>
    {
        public int IdLiquidacion { get; set; } 
        public double ValorTotalNomina { get; set; }
        public double Sena { get; set; }
        public double Icbf { get; set; }
        public double Comfacesar { get; set; }
        public double Total { get; set; }

        public TotalLiquidacion(int idLiquidacion, double valorTotalNomina, double sena, double icbf, double comfacesar, double total)
        {
            IdLiquidacion = idLiquidacion;
            ValorTotalNomina = valorTotalNomina;
            Sena = sena;
            Icbf = icbf;
            Comfacesar = comfacesar;
            Total = total;
        }

        public IReadOnlyList<string> CanCrear(TotalLiquidacion totalLiquidacion)
        {
            var errors = new List<string>();
            if (totalLiquidacion.IdLiquidacion == 0)
                errors.Add("Campo Identificacion Liquidacion vacio");
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
    }
}

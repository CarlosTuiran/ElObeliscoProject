using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Base;

namespace Domain.Models.Entities
{
    public class Liquidacion : Entity<int>
    {
        public int IdLiquidacion { get; set; }
        public int NominaId { get; set; }
        public DateTime FechaPago { get; set; }
        public double Monto { get; set; }
        public Liquidacion()
        {
                
        }
        public Liquidacion(int idNomina, double monto)
        {
            NominaId = idNomina;
            FechaPago = DateTime.Today;
            Monto = monto;
        }

        public IReadOnlyList<string> CanCrear(Liquidacion liquidacion)
        {
            var errors = new List<string>();
            if (this.IdLiquidacion == 0)
                errors.Add("Campo Identificacion liquidacion vacio");
            if (this.NominaId == 0)
                errors.Add("Campo Identificacion nomina vacio");
            if (this.Monto == 0)
                errors.Add("Campo Monto vacio");

            return errors;
        }

    }
}

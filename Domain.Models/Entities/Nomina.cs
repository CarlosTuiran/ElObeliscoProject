using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Base.BaseEntity;

namespace Domain.Models.Entities
{
    public class Nomina : Entity<int>
    {
        
        public int IdNomina { get; set; }
        public int IdEmpleado { get; set; }
        public double SaldoBase { get; set; }
        public double Seguro { get; set; }
        public double SaldoTotal { get => SaldoBase + Seguro; }
        public List<Empleado> Empleado { get; set; } //Relacion 1 a * con empleado 
        public List<Liquidacion> Liquidacions { get; set; }
        public Nomina(int idEmpleado, double saldoBase, double seguro)
        {
            IdEmpleado = idEmpleado;
            SaldoBase = saldoBase;
            Seguro = seguro;
            
        }
        public Nomina()
        {

        }
        public IReadOnlyList<string> CanCrear(Nomina nomina)
        {
            var errors = new List<string>();
            if (nomina.IdEmpleado == 0)
                errors.Add("Campo identificacion vacio");
            if (nomina.SaldoBase == 0)
                errors.Add("Campo Saldo base vacio");
            if (nomina.SaldoTotal == 0)
                errors.Add("Campo Salto total Vacio");
            if (nomina.Seguro == 0)
                errors.Add("Campo Seguro vacio");
            return errors;
        }
    }
}

using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Nomina : Entity<int>
    {
        
        public int IdEmpleado { get; set; }
        public double SaldoBase { get; set; }
        public double Seguro { get; set; }
        public double SaldoTotal { get; set; }
        public Nomina()
        {

        }

    }
}

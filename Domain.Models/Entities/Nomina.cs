using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Base.BaseEntity;

namespace Domain.Models.Entities
{
    public class Nomina : Entity<int>
    {
        public int id { get; set; }
        public int IdEmpleado { get; set; }
        public double SaldoBase { get; set; }
        public double Seguro { get; set; }
        public double SaldoTotal { get; set; }
        public Nomina()
        {

        }

    }
}

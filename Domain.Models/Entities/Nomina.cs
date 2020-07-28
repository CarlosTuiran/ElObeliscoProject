﻿using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Base.BaseEntity;

namespace Domain.Models.Entities
{
    public class Nomina : Entity<int>
    {
        
        public int IdEmpleado { get; set; }
        public double SaldoBase { get; set; }
        public double Seguro { get; set; }
        public double SaldoTotal { get; set; }

        public Nomina(int idEmpleado, double saldoBase, double seguro, double saldoTotal)
        {
            IdEmpleado = idEmpleado;
            SaldoBase = saldoBase;
            Seguro = seguro;
            SaldoTotal = saldoTotal;
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

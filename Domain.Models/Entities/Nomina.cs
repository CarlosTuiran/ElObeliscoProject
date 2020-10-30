using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Nomina : Entity<int>
    {
        
        public string IdNomina { get; set; }
        public int IdEmpleado { get; set; }
        public int DiasTrabajados { get; set; }
        public int HorasExtras { get; set; }
        public double SalarioBase { get; set; }
        public double SubTransporte { get; set; }

        public Nomina(string idNomina, int idEmpleado, int diasTrabajados, int horasExtras, double salarioBase, double subTransporte)
        {
            IdNomina = idNomina;
            IdEmpleado = idEmpleado;
            DiasTrabajados = diasTrabajados;
            HorasExtras = horasExtras;
            SalarioBase = salarioBase;
            SubTransporte = subTransporte;
        }

        public Nomina()
        {

        }
        public IReadOnlyList<string> CanCrear(Nomina nomina)
        {
            var errors = new List<string>();
            if (nomina.IdEmpleado == 0)
                errors.Add("Campo Identificacion Empleado vacio");
            if (nomina.DiasTrabajados == 0)
                errors.Add("Campo Dias Trabajados vacio");
            if (nomina.SalarioBase == 0)
                errors.Add("Campo Salario Base vacio");
            if (string.IsNullOrEmpty(nomina.IdNomina))
                errors.Add("Campo Subsidio Identificacion Nomina vacio");
            return errors;
        }
    }
}

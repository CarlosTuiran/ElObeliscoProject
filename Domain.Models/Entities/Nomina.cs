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
        public double HoraExtraDiurna { get; set; }
        public double HoraExtraNocturna { get; set; }
        public double HoraExtraDiurnaFestivo { get; set; }
        public double HoraExtraNocturnaFestivo { get; set; }
        public double SalarioBase { get; set; }
        public double Comisiones { get; set; }
        public List<Liquidacion> Liquidacion { get; set; }

        public Nomina(string idNomina, int idEmpleado, int diasTrabajados, double horaExtraDiurna, 
            double horaExtraNocturna, double horaExtraDiurnaFestivo, double horaExtraNocturnaFestivo, 
            double salarioBase, double comisiones)
        {
            IdNomina = idNomina;
            IdEmpleado = idEmpleado;
            DiasTrabajados = diasTrabajados;
            HoraExtraDiurna = horaExtraDiurna;
            HoraExtraNocturna = horaExtraNocturna;
            HoraExtraDiurnaFestivo = horaExtraDiurnaFestivo;
            HoraExtraNocturnaFestivo = horaExtraNocturnaFestivo;
            SalarioBase = salarioBase;
            Comisiones = comisiones;
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
            if (nomina.Comisiones == 0)
                errors.Add("Campo Comisiones Base vacio");
            if (nomina.DiasTrabajados == 0)
                errors.Add("Campo Dias Trabajados Base vacio");
            if (string.IsNullOrEmpty(nomina.IdNomina))
                errors.Add("Campo Subsidio Identificacion Nomina vacio");
            return errors;
        }
    }
}

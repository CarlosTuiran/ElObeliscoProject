using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarNominaRequest
    {
        readonly int Month = DateTime.Now.Month;
        readonly int Year = DateTime.Now.Year;
        public int Id { get; set; }
        public string IdNomina { get => Month + " - " + Year; }
        public int IdEmpleado { get; set; }
        public int DiasTrabajados { get; set; }
        public double HoraExtraDiurna { get; set; }
        public double HoraExtraNocturna { get; set; }
        public double HoraExtraDiurnaFestivo { get; set; }
        public double HoraExtraNocturnaFestivo { get; set; }
        public double SalarioBase { get; set; }
    }
    public class ActualizarNominaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Empleado en Nomina Actualizado Exitosamente");
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearNominaRequest
    {
        string Month = DateTime.Now.Month.ToString();
        string Year = DateTime.Now.Year.ToString();

        public string IdNomina { get => Month + "de" + Year; }
        public int IdEmpleado { get; set; }
        public int DiasTrabajados { get; set; }
        public double SalarioBase { get; set; }
        public string SubTransporte { get; set; }
    }
    public class CrearNominaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Empleado en Nomina Creado Exitosamente");
        }
    }
}
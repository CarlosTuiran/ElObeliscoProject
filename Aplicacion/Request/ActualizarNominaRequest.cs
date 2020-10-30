using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarNominaRequest
    {
        public string IdNomina { get; set; }
        public int IdEmpleado { get; set; }
        public int DiasTrabajados { get; set; }
        public int HorasExtras { get; set; }
        public double SalarioBase { get; set; }
        public double SubTransporte { get; set; }
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


using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarNominaRequest
    {
        public int IdEmpleado { get; set; }
        public double SaldoBase { get; set; }
        public double Seguro { get; set; }
        public double SaldoTotal { get; set; }
    }
    public class ActualizarNominaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Nomina Actualizada Exitosamente");
        }
    }
}


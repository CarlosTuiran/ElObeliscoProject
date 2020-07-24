using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearNominaRequest
    {
        public int id { get; set; }
        public int IdEmpleado { get; set; }
        public double SaldoBase { get; set; }
        public double Seguro { get; set; }
        public double SaldoTotal { get; set; }

        public class CrearNominaResponse
        {
            public string Message { get; set; }
            public bool isOk()
            {
                return this.Message.Equals("Nomina Creado Exitosamente");
            }
        }
    }
}

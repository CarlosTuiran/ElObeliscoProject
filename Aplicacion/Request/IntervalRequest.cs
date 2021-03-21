using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class IntervalRequest
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
    public class IntervalResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Es necesario un response??? :>");
        }
    }
}

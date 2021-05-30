using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearParametrosRequest
    {
        public string Agrupacion { get; set; }
        public double ValorNumerico { get; set; }
        public string ValorTxt { get; set; }
        public string Descripcion { get; set; }

    }
    public class CrearParametrosResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Parametro Creado Exitosamente");
        }
    }
}

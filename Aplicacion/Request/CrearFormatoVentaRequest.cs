using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearFormatoVentaRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public string Metrica { get; set; }
        public double FactorConversion { get; set; }

    }
    public class CrearFormatoVentaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Formato Creado Exitosamente");
        }
    }
}

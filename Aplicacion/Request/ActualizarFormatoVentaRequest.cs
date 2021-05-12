using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarFormatoVentaRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public string Metrica { get; set; }
        public double FactorConversion { get; set; }
    }

    public class ActualizarFormatoVentaResponse
    {
        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Formato Actualizado Exitosamente");
        }
    }
}

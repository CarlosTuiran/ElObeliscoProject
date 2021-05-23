using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarCuentaRequest
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Naturaleza { get; set; }
        public string Clase { get; set; }
    }
    public class ActualizarCuentaResponse
    {
        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Cuenta Actualizada Exitosamente");
        }
    }
}

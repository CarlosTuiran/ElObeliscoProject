using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearCuentaRequest
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Naturaleza { get; set; }
        public string Clase { get; set; }
    }
    public class CrearCuentaResponse
    {
        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Cuenta Creada Exitosamente");
        }
    }
}

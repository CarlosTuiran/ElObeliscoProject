using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearMarcaRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class CrearMarcaResponse
    {
        public string Message { get; set; }

        public CrearMarcaResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Marca Creada Exitosamente");
        }
    }
}

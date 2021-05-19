using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarMarcaRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class ActualizarMarcaResponse
    {
        public string Message { get; set; }

        public ActualizarMarcaResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Marca Actualizada Exitosamente");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarCategoriaRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class ActualizarCategoriaResponse
    {
        public string Message { get; set; }

        public ActualizarCategoriaResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Categoria Actualizada Exitosamente");
        }
    }
}

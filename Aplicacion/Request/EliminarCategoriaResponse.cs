using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarCategoriaResponse
    {
        public EliminarCategoriaResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool IsOk()
        {
            return this.Message.Equals("Categoría Eliminada Exitosamente");
        }
    }
}

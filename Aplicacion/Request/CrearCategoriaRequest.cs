using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearCategoriaRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class CrearCategoriaResponse
    {
        public string Message { get; set; }

        public CrearMarcaResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Categoria Actualizada Exitosamente");
        }
    }
}

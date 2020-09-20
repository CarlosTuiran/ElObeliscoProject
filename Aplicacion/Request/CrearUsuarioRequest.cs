using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearUsuarioRequest
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int EmpleadoId { get; set; }
        public string Tipo { get; set; }
    }
    public class CrearUsuarioResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Usuario Creado Exitosamente");
        }
    }
}

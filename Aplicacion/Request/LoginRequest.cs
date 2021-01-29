using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public string EmpleadoId { get; set; }
        public string Rol { get; set; }

        
        public bool isOk()
        {
            return this.Message.Equals("Usuario y Contraseña Correctos");
        }
    }
}

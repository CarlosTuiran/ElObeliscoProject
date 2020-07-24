using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearEmpleadoRequest
    {
        public int IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cargo { get; set; }
        public int Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }

        public class CrearEmpleadoResponse
        {
            public string Message { get; set; }
            public bool isOk()
            {
                return this.Message.Equals("Empleado Creado Exitosamente");
            }
        }
    }
}

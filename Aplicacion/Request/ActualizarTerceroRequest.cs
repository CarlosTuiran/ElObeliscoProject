using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarTerceroRequest
    {
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoTercero { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
    public class ActualizarTerceroResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Tercero Actualizado Exitosamente");
        }
    }
}

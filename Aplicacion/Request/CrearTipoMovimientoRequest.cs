using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearTipoMovimientoRequest
    {
        public int idMovimiento { get; set; }
        public string Nombre { get; set; }
        
    }
    public class CrearTipoMovimientoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Empleado Creado Exitosamente");
        }
    }
}

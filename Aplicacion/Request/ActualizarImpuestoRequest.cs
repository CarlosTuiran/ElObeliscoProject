using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ActualizarImpuestoRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Tarifa { get; set; }
        public string Tipo { get; set; }
        public bool Activo { get; set; }
    }
    public class ActualizarImpuestoResponse
    {
        public string Message { get; set; }

        public ActualizarImpuestoResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Impuesto Actualizado Exitosamente");
        }
    }
}

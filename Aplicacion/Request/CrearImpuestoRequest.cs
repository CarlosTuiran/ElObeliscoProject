using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearImpuestoRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Tarifa { get; set; }
        public string Tipo { get; set; }
        public bool Activo { get => true; }
    }
    public class CrearImpuestoResponse
    {
        public string Message { get; set; }

        public CrearImpuestoResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Impuesto Creado Exitosamente");
        }
    }
}

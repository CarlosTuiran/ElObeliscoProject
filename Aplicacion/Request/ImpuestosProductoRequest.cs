using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class ImpuestosProductoRequest
    {
        public int Id { get;set; }
        public string IdProducto { get; set; }
        public int IdImpuesto { get; set; }
    }
    public class ActualizarImpuestosProductoResponse
    {
        public string Message { get; set; }

        public ActualizarImpuestosProductoResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Impuestos/devengados Actualizados Exitosamente");
        }
    }    
    public class CrearImpuestosProductoResponse
    {
        public string Message { get; set; }

        public CrearImpuestosProductoResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Impuestos/devengados Creados Exitosamente");
        }
    }
    public class EliminarImpuestosProductoResponse
    {
        public string Message { get; set; }

        public EliminarImpuestosProductoResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Impuestos/devengados Elimiados Exitosamente");
        }
    }
}

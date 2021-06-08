using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class BodegaRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class ActualizarBodegaResponse
    {
        public string Message { get; set; }

        public ActualizarBodegaResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Bodega Actualizado Exitosamente");
        }
    }
    public class CrearBodegaResponse
    {
        public string Message { get; set; }

        public CrearBodegaResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Bodega Creado Exitosamente");
        }
    }
    public class EliminarBodegaResponse
    {
        public string Message { get; set; }

        public EliminarBodegaResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Bodega Elimiado Exitosamente");
        }
    }
}

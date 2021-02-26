using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class EliminarPromocionesRequest
    {
        public int Id { get; set; }
    }
    public class EliminaPromocionesResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Promocion Eliminado Exitosamente");
        }
    }
}

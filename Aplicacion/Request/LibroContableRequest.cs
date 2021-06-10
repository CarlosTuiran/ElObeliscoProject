using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class LibroContableRequest
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int TipoMovimientoId  { get; set; }
        public double Valor  { get; set; }
        public int OrigenId { get; set; }
        public string OrigenTipo { get; set; }
        public DateTime Fecha { get => DateTime.Now.Date; }
    }
    public class CrearLibroContableResponse
    {
        public string Message { get; set; }

        public CrearLibroContableResponse(string message)
        {
            Message = message;
        }

        public bool IsOk()
        {
            return this.Message.Equals("Libro Contable Creado Exitosamente");
        }
    }
}

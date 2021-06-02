using System;
using System.Collections.Generic;

namespace Aplicacion.Request.Salidas
{
    public class ConsultarLibroContableResponse
    {
        public string NombreMov { get; set; }
        public string Serial { get; set; }
        public List<ListConsultarLibroContableResponse> Responses { get; set; }
    }
    public class ListConsultarLibroContableResponse
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Debe { get; set; }
        public string Haber { get; set; }
        public int OrigenId { get; set; }
        public string OrigenTipo { get; set; }
        public string Fecha { get; set; }
    }

}
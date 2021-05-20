using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request
{
    public class CrearTerceroRequest
    {
        public string Identificacion { get; set; }
        public string TipoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoTercero { get; set; }
        public string TipoPersona { get; set; }
        public string ActividadEconomica { get; set; }
        public string ResponsabilidadFiscal { get; set; }      
        public bool ResponsableIva { get; set; }
        public bool AutoRetenedor { get; set; }
        public bool Extranjero { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string? Descripcion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Estado { get => "Activo"; }
        public DateTime FechaCumple { get; set; }   

    }
    public class CrearTerceroResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Tercero Creado Exitosamente");
        }
    }
}

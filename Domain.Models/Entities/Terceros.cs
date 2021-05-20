using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Base.BaseEntity;

namespace Domain.Models.Entities
{
    public class Terceros : Entity<int>
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
        public string Estado { get; set; }
        public DateTime FechaCumple { get; set; }
        public List<MFactura> MFacturas { get; set; }
        public Terceros()
        {

        }
        public Terceros(string identificacion, string tipoId,string nombre, string apellido, string tipoTercero, 
            string tipoPersona,  string actividadEconomica,string responsabilidadFiscal, bool responsableIva 
            , bool autoRetenedor,bool extranjero, string celular, string correo, string direccion, string descripcion, 
            string ciudad, string telefono, string estado, DateTime fechaCumple)
        {
            Identificacion = identificacion;
            TipoId=tipoId;
            Nombre = nombre;
            Apellido = apellido;
            TipoPersona=tipoPersona;
            TipoTercero = tipoTercero;
            ActividadEconomica=actividadEconomica;
            ResponsabilidadFiscal=responsabilidadFiscal;
            ResponsableIva=responsableIva;
            AutoRetenedor=autoRetenedor;
            Extranjero=extranjero;
            Celular = celular;
            Correo = correo;
            Direccion = direccion;
            Descripcion = descripcion;
            Ciudad = ciudad;
            Telefono = telefono;
            Estado = estado;
            FechaCumple=fechaCumple;
        }

        public IReadOnlyList<string> CanCrear(Terceros terceros)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(this.Identificacion))
                errors.Add("Campo Identificacion vacio");
            if (string.IsNullOrEmpty(this.Nombre))
                errors.Add("Campo Nombre vacio");            
            if (string.IsNullOrEmpty(this.TipoTercero))
                errors.Add("Campo TipoTercero vacio");
            if (string.IsNullOrEmpty(this.Celular))
                errors.Add("Campo Celular vacio");
            if (string.IsNullOrEmpty(this.Correo))
                errors.Add("Campo Correo vacio");
            if (string.IsNullOrEmpty(this.Direccion))
                errors.Add("Campo Direccion vacio");
            return errors;
        }
    }
}

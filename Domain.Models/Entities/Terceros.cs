using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Base.BaseEntity;

namespace Domain.Models.Entities
{
    public class Terceros : Entity<int>
    {
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoTercero { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string? Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCumple { get; set; }
        public List<MFactura> MFacturas { get; set; }
        public Terceros()
        {

        }
        public Terceros(string nit, string nombre, string apellido, string tipoTercero, string celular, string correo, string direccion, string descripcion, string estado, DateTime fechaCumple)
        {
            Nit = nit;
            Nombre = nombre;
            Apellido = apellido;
            TipoTercero = tipoTercero;
            Celular = celular;
            Correo = correo;
            Direccion = direccion;
            Descripcion = descripcion;
            Estado = estado;
            FechaCumple=fechaCumple;
        }

        public IReadOnlyList<string> CanCrear(Terceros terceros)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(this.Nit))
                errors.Add("Campo Nit vacio");
            if (string.IsNullOrEmpty(this.Nombre))
                errors.Add("Campo Nombre vacio");
            if (string.IsNullOrEmpty(this.Apellido))
                errors.Add("Campo Apellido vacio");
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

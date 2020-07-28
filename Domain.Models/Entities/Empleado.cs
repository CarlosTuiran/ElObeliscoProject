using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Base;

namespace Domain.Models.Entities
{
    public class Empleado:Entity<int>
    {
        public int IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string  Cargo { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }

        public Empleado(int idEmpleado, string nombres, string apellidos, string cargo, string celular, string correo, string direccion, string estado)
        {
            IdEmpleado = idEmpleado;
            Nombres = nombres;
            Apellidos = apellidos;
            Cargo = cargo;
            Celular = celular;
            Correo = correo;
            Direccion = direccion;
            Estado = estado;
        }
        public IReadOnlyList<string> CanCrear(Empleado empleado)
        {
            var errors = new List<string>();
            if (this.IdEmpleado == 0)
                errors.Add("Campo Identificacion empleado vacio");
            if (string.IsNullOrEmpty(this.Apellidos))
                errors.Add("Campo Apellidos vacio");
            if (string.IsNullOrEmpty(this.Cargo))
                errors.Add("Campo Cargo vacio");
            if (string.IsNullOrEmpty(this.Celular))
                errors.Add("Campo Celular vacio");
            if (string.IsNullOrEmpty(this.Correo))
                errors.Add("Campo Correo vacio");
            if (string.IsNullOrEmpty(this.Direccion))
                errors.Add("Campo Direccion vacio");
            if (string.IsNullOrEmpty(this.Estado))
                errors.Add("Campo Estado vacio");
            if (string.IsNullOrEmpty(this.Nombres))
                errors.Add("Campo Nombres vacio");
            return errors;
        }
    }
}

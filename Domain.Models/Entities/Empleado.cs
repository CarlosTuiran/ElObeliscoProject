using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Base;

namespace Domain.Models.Entities
{
    public class Empleado : Entity<int>
    {
        public int IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cargo { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public List<MFactura> MFacturas { get; set; }
        public Usuario Usuario { get; set; }
        public Empleado()
        {

        }
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
            if (empleado.IdEmpleado == 0)
                errors.Add("Campo Identificacion empleado vacio");
            if (string.IsNullOrEmpty(empleado.Apellidos))
                errors.Add("Campo Apellidos vacio");
            if (string.IsNullOrEmpty(empleado.Cargo))
                errors.Add("Campo Cargo vacio");
            if (string.IsNullOrEmpty(empleado.Celular))
                errors.Add("Campo Celular vacio");
            if (string.IsNullOrEmpty(empleado.Correo))
                errors.Add("Campo Correo vacio");
            if (string.IsNullOrEmpty(empleado.Direccion))
                errors.Add("Campo Direccion vacio");
            if (string.IsNullOrEmpty(empleado.Nombres))
                errors.Add("Campo Nombres vacio");
            return errors;
        }
    }
}

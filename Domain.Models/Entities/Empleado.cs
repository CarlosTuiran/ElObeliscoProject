using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string  Cargo { get; set; }
        public int Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public Empleado()
        {

        }

    }
}

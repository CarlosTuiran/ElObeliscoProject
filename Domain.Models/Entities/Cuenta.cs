using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Cuenta : Entity<int>
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public string Naturaleza { get; set; }

        public Cuenta(string nombre, string tipo, string codigo, string naturaleza)
        {
            Nombre = nombre;
            Tipo = tipo;
            Codigo = codigo;
            Naturaleza = naturaleza;
        }
        public IReadOnlyList<string> CanCrear(Cuenta cuenta)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(cuenta.Nombre))
                errors.Add("Campo Nombre vacio");
            if (string.IsNullOrEmpty(cuenta.Tipo))
                errors.Add("Campo Tipo vacio");
            if (string.IsNullOrEmpty(cuenta.Codigo))
                errors.Add("Campo Codigo vacio");
            if (string.IsNullOrEmpty(cuenta.Naturaleza))
                errors.Add("Campo Naturaleza vacio");
            return errors;
        }
    }
}

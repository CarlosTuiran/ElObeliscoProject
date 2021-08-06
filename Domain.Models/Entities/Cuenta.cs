using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Cuenta : Entity<int>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Naturaleza { get; set; }
        public string Clase { get; set; }

        public Cuenta()
        {
        }

        public Cuenta(int codigo, string nombre, string naturaleza, string clase)
        {
            Codigo = codigo;
            Nombre = nombre;
            Naturaleza = naturaleza;
            Clase = clase;
        }

        public IReadOnlyList<string> CanCrear(Cuenta cuenta)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(cuenta.Codigo.ToString()))
                errors.Add("Campo Nombre vacio");
            if (string.IsNullOrEmpty(cuenta.Nombre))
                errors.Add("Campo Tipo vacio");
            if (string.IsNullOrEmpty(cuenta.Naturaleza))
                errors.Add("Campo Codigo vacio");
            if (string.IsNullOrEmpty(cuenta.Clase))
                errors.Add("Campo Naturaleza vacio");
            return errors;
        }
    }
}

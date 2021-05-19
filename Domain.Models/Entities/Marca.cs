using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Marca : Entity<int>
    {
        public string Nombre { get; set; }

        public Marca(string nombre)
        {
            Nombre = nombre;
        }
        public IReadOnlyList<string> CanCrear(Marca marca)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(marca.Nombre))
                errors.Add("Campo Nombre vacio");
            return errors;
        }
    }
}

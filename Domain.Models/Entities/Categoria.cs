using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Categoria : Entity<int>
    {
        public string Nombre { get; set; }

        public Categoria(string nombre)
        {
            Nombre = nombre;
        }

        public Categoria()
        {
        }

        public IReadOnlyList<string> CanCrear(Categoria categoria)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(categoria.Nombre))
                errors.Add("Campo Nombre vacio");
            return errors;
        }
    }
}

using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Bodega : Entity<int>
    {
        public string Nombre { get; set; }

        public Bodega(string nombre)
        {
            Nombre = nombre;
        }
        public Bodega()
        {
        }

        public IReadOnlyList<string> CanCrear(Bodega bodega)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(bodega.Nombre))
                errors.Add("Campo Nombre vacio");
            return errors;
        }
    }
}

using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Impuesto : Entity<int>
    {
        public string Nombre { get; set; }
        public double Tarifa { get; set; }
        public string Tipo { get; set; }
        public bool Activo { get; set; }
        public Impuesto(string nombre, double tarifa, string tipo, bool activo)
        {
            Nombre = nombre;
            Tarifa = tarifa;
            Tipo = tipo;
            Activo = activo;
        }

        public Impuesto()
        {
        }

        public IReadOnlyList<string> CanCrear(Impuesto impuesto)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(impuesto.Nombre))
                errors.Add("Campo Nombre vacio");
            if (string.IsNullOrEmpty(impuesto.Tarifa.ToString()))
                errors.Add("Campo Tarifa vacio");
            if (string.IsNullOrEmpty(impuesto.Tipo))
                errors.Add("Campo Tipo vacio");
            return errors;
        }
    }
}

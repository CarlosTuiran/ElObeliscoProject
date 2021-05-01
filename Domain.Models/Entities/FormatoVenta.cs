using Domain.Models.Base;
using System.Collections.Generic;

namespace Domain.Models.Entities
{
    public class FormatoVenta : Entity<int>
    {
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public string Metrica { get; set; }
        public double FactorConversion { get; set; }

        public FormatoVenta(string nombre, string abreviacion, string metrica, double factorConversion)
        {
            Nombre = nombre;
            Abreviacion = abreviacion;
            Metrica = metrica;
            FactorConversion = factorConversion;
        }
        public FormatoVenta(){
            
        }

        public IReadOnlyList<string> CanCrear(FormatoVenta formatoVenta)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(formatoVenta.Nombre))
                errors.Add("Campo Nombre vacio");
            if (string.IsNullOrEmpty(formatoVenta.Abreviacion))
                errors.Add("Campo Abreviacion vacio");
            if (string.IsNullOrEmpty(formatoVenta.Metrica))
                errors.Add("Campo Metrica vacio");
            if (formatoVenta.FactorConversion == 0)
                errors.Add("Campo FactorConversion vacio");
            return errors;
        }

    }
}

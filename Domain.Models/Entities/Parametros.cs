using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Parametros : Entity<int>
    {        
        public string Agrupacion { get; set; }
        public double ValorNumerico  { get; set; }
        public string ValorTxt {get; set;}
        public string Descripcion { get; set; }

        public Parametros(string agrupacion, double valorNumerico, string valorTxt, string descripcion)
        {
            Agrupacion = agrupacion;
            ValorNumerico = valorNumerico;
            ValorTxt = valorTxt;
            Descripcion = descripcion;
        }

        public Parametros()
        {

        }
        public IReadOnlyList<string> CanCrear(Parametros parametros)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(parametros.Agrupacion))
                errors.Add("Campo Agrupacion vacio");
            return errors;
        }
    }
}

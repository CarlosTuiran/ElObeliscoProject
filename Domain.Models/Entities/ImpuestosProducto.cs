using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class ImpuestosProducto : Entity<int>
    {
        public string IdProducto { get; set; }
        public int IdImpuesto { get; set; }

        public ImpuestosProducto(string idProducto, int idImpuesto)
        {
            IdProducto = idProducto;
            IdImpuesto = idImpuesto;
        }
        public IReadOnlyList<string> CanCrear(ImpuestosProducto impuestosProducto)
        {
            var errors = new List<string>();
            if (impuestosProducto.IdImpuesto == 0)
                errors.Add("Campo Impuesto vacio");
            if (string.IsNullOrEmpty(impuestosProducto.IdProducto))
                errors.Add("Campo Producto vacio");
            return errors;
        }
    }
}

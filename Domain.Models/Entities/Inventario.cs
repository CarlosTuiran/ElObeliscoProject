using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Base.BaseEntity;

namespace Domain.Models.Entities
{
    public class Inventario : Entity<int>
    {
        public double id { get; set; }
        public string Referencia { get; set; }
        public int Cantidad { get; set; }
        public string Bodega { get; set; }

        public Inventario(double id, string referencia, int cantidad, string bodega)
        {
            this.id = id;
            Referencia = referencia;
            Cantidad = cantidad;
            Bodega = bodega;
        }

        public IReadOnlyList<string> CanCrear(Inventario inventario)
        {
            var errors = new List<string>();
            if (this.Cantidad == 0)
                errors.Add("Campo Cantidad vacio");
            if (this.Referencia == null)
                errors.Add("Campo Referencia vacio");
            if (this.Bodega == null)
                errors.Add("Campo Bodega vacio");
            return errors;
        }
    }
}

using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Models.Entities
{
    public class Inventario : Entity<int>
    {
        
        public string Referencia { get; set; }
        public int Cantidad { get; set; }
        public string Bodega { get; set; }
        public List<Producto> Productos { get; set; }
        public Inventario()
        {

        }
        public Inventario(string referencia, int cantidad, string bodega)
        {
            
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

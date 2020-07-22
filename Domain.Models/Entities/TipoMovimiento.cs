using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class TipoMovimiento
    {
        public int idMovimiento { get; set; }
        public string Nombre { get; set; }

        public TipoMovimiento(int idMovimiento, string nombre)
        {
            this.idMovimiento = idMovimiento;
            Nombre = nombre;
        }

        public IReadOnlyList<string> CanCrear(MFactura mFactura)
        {
            var errors = new List<string>();
            if (this.idMovimiento == 0)
                errors.Add("Campo idMovimiento vacio");
            if (string.IsNullOrEmpty(this.Nombre))
                errors.Add("Campo Nombre vacio");
            
            return errors;
        }
    }
}

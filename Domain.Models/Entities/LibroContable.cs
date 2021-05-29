using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class LibroContable : Entity<int>
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public double? Debe { get; set; }            
        public double? Haber { get; set; }
        public int OrigenId { get; set; }
        public string OrigenTipo { get; set; }
        public DateTime Fecha { get; set; }

        public LibroContable(int codigo, string descripcion, int origenId, string origenTipo, DateTime fecha)
        {
            Codigo = codigo;
            Descripcion = descripcion;           
            OrigenId = origenId;
            OrigenTipo = origenTipo;
            Fecha = fecha;
        }
    }
}

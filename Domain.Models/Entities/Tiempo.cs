using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
	public class Tiempo : Entity<int>
    {
		public DateTime Fecha { get; set; }
		public int Año { get; set; }
		public int Mes { get; set; }
		public int Dia { get; set; }
		public int DiaDelAño { get; set; }
		public int SemanaDelAño { get; set; }
		public int Trimestre { get; set; }
		public int Semestre { get; set; }
		public string NombreMes { get; set; }
		public string NombreMesCorto { get; set; }
		public string NombreDia { get; set; }
		public string NombreDiaCorto { get; set; }
        public Tiempo()
        {

        }
	}
}

using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
	public class Tiempo : Entity<int>
    {
		public int IdFecha { get; set; }
		public DateTime Fecha { get; set; }
		public int Dia_Semana { get; set; }
		public int Dia_Mes { get; set; }
		public int Dia_Anio { get; set; }
		public int Semana_Anio { get; set; }
		public int Mes_Anio { get; set; }
		public int Cuatrimestre_Anio { get; set; }
		public int Semestre_Anio { get; set; }
		public string Anio { get; set; }
		public string Anio_Semana { get; set; }
		public string Anio_Mes { get; set; }
		public string Anio_Cuatrimestre { get; set; }
		public string Anio_Semestre { get; set; }
		public string Dia_Semana_Descripcion { get; set; }
		public string Mes_Descripcion { get; set; }
		public Tiempo()
        {

        }
	}
}

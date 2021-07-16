using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Request.Salidas
{
    public class ConsultarEstadoResultadoResponse
    {
        public string NombreMov { get; set; }
        public string Serial { get; set; }
        public string UtilidadBrutaTotal { get; set; }
        public string UtilidadNetaTotal { get; set; }
        public string UtilidadOperativaTotal { get; set; }
        public string UtilidadAntesImpuestoTotal { get; set; }
        public List<CuentasBalances> UtilidadesBrutas { get; set; }
        public List<CuentasBalances> UtilidadesOperativas { get; set; }
        public List<CuentasBalances> UtilidadesAntesImpuestos { get; set; }

    }
}

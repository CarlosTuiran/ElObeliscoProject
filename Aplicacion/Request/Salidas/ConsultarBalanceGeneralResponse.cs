using System.Collections.Generic;

namespace Aplicacion.Request.Salidas
{
    public class ConsultarBalanceGeneralResponse
    {   
        public string NombreMov { get; set; }
        public string Serial { get; set; }
        public List<CuentasBalances> ActivosCorrientes { get; set; }
        public List<CuentasBalances> PasivosCorrientes { get; set; }
        public List<CuentasBalances> Patrimonio { get; set; }
        public string PatrimonioTotal { get; set; }
        public string ActivoCorrienteTotal { get; set; }
        public string ActivoTotal { get; set; }
        public string PasivoCorrienteTotal { get; set; }
        public string PasivoTotal { get; set; }
    }
    public class CuentasBalances{
        public string Concepto { get; set; }
        public string ValorTotal { get; set; }
        public double? ValorNumerico { get; set; }
    }

}
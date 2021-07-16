using Aplicacion.Request.Salidas;
using Infra.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.ConsultarServices
{
    public class ConsultarEstadoResultadoService
    {
        readonly ObeliscoContext _context;
        readonly ConsultarEstadoResultadoResponse response;
        public ConsultarEstadoResultadoService(ObeliscoContext context)
        {
            _context = context;
            response = new ConsultarEstadoResultadoResponse
            {
                UtilidadesBrutas = new List <CuentasBalances >(),
                UtilidadesOperativas = new List<CuentasBalances>(),
                UtilidadesAntesImpuestos= new List<CuentasBalances>()
            };
        }
        //public ConsultarEstadoResultadoResponse Ejecutar()
        //{

        //}
    }
}

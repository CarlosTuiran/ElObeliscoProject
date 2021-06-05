using Aplicacion.Request.Salidas;
using Domain.Models.Entities;
using Infra.Datos;
using System.Linq;

namespace Aplicacion.Services.ConsultarServices
{
    public class ConsultarTotalLiquidacionService
    {
        readonly ObeliscoContext _context;
        readonly ConsultarTotalLiquidacionResponse _response;

        public ConsultarTotalLiquidacionService(ObeliscoContext context)
        {
            _context = context;
            _response = new ConsultarTotalLiquidacionResponse();
        }

        public ConsultarTotalLiquidacionResponse Ejecutar(string idNomina)
        {
            var totalLiquidacion = (from t in _context.Set<TotalLiquidacion>()
                                    where t.NominaId == idNomina
                                    select new
                                    {
                                        t.Mes,
                                        t.Anio,
                                        t.ValorTotalNomina,
                                        t.Sueldo,
                                        t.SubTransporte,
                                        t.TotalDevengado,
                                        t.Comisiones,
                                        t.Salud_Empleador,
                                        t.Salud_Trabajador,
                                        t.Salud,
                                        t.Pension_Trabajador,
                                        t.Pension_Empleador,
                                        t.Pension,
                                        t.Prima,
                                        t.Cesantias,
                                        t.Int_Cesantias,
                                        t.Vacaciones,
                                        t.Arl,
                                        t.Caja_Comp,
                                        t.ICBF,
                                        t.SENA,
                                        t.RetencionAporteNomina,
                                        t.AcreedoresVarios,
                                        t.Provision,
                                        t.SalariosPagar,
                                        t.Parafiscales,
                                        t.NominaId,
                                    }).FirstOrDefault(t => t.NominaId == idNomina);


            _response.Mes = totalLiquidacion.Mes;
            _response.Anio = totalLiquidacion.Anio;
            _response.ValorTotalNomina = totalLiquidacion.ValorTotalNomina.ToString("C2");
            _response.Sueldo = totalLiquidacion.Sueldo.ToString("C2");
            _response.SubTransporte = totalLiquidacion.SubTransporte.ToString("C2");
            _response.TotalDevengado = totalLiquidacion.TotalDevengado.ToString("C2");
            _response.Comisiones = totalLiquidacion.Comisiones.ToString("C2");
            _response.Salud_Empleador = totalLiquidacion.Salud_Empleador.ToString("C2");
            _response.Salud_Trabajador = totalLiquidacion.Salud_Trabajador.ToString("C2");
            _response.Salud = totalLiquidacion.Salud.ToString("C2");
            _response.Pension_Trabajador = totalLiquidacion.Pension_Trabajador.ToString("C2");
            _response.Pension_Empleador = totalLiquidacion.Pension_Empleador.ToString("C2");
            _response.Pension = totalLiquidacion.Pension.ToString("C2");
            _response.Prima = totalLiquidacion.Prima.ToString("C2");
            _response.Cesantias = totalLiquidacion.Cesantias.ToString("C2");
            _response.Int_Cesantias = totalLiquidacion.Int_Cesantias.ToString("C2");
            _response.Vacaciones = totalLiquidacion.Vacaciones.ToString("C2");
            _response.Arl = totalLiquidacion.Arl.ToString("C2");
            _response.Caja_Comp = totalLiquidacion.Caja_Comp.ToString("C2");
            _response.ICBF = totalLiquidacion.ICBF.ToString("C2");
            _response.SENA = totalLiquidacion.SENA.ToString("C2");
            _response.RetencionAporteNomina = totalLiquidacion.RetencionAporteNomina.ToString("C2");
            _response.AcreedoresVarios = totalLiquidacion.AcreedoresVarios.ToString("C2");
            _response.Provision = totalLiquidacion.Provision.ToString("C2");
            _response.SalariosPagar = totalLiquidacion.SalariosPagar.ToString("C2");
            _response.Parafiscales = totalLiquidacion.Parafiscales.ToString("C2");
            _response.NominaId = totalLiquidacion.NominaId;
            _response.NombreMov = "Total Liquidación";
            _response.Serial = _response.NominaId;

            return _response;
        }
    }
}

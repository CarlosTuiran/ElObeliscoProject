using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Services.Eventos
{
    public class PagarEmpleadoService
    {
        readonly IUnitOfWork _unitOfWork;
        public PagarEmpleadoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagarEmpleadoResponse Ejecutar(PagarEmpleadoRequest request)
        {

            var liquidacion = _unitOfWork.LiquidacionServiceRepository.FindFirstOrDefault(t => t.NominaId == request.IdNomina && t.IdEmpleado == request.IdEmpleado);

            if (liquidacion != null)
            {
                return new PagarEmpleadoResponse() { Message = $"Ya le ha pagado a este empleado" };
            }
            var nomina = _unitOfWork.NominaServiceRepository.FindFirstOrDefault(t => t.IdEmpleado == request.IdEmpleado && t.IdNomina == request.IdNomina);
            var parametrosNomina = _unitOfWork.ParametrosServiceRepository.FindBy(t => t.Agrupacion == "ParametrosNomina");
            var parametrosHorasExtras = _unitOfWork.ParametrosServiceRepository.FindBy(t => t.Agrupacion == "ParametrosHorasExtras");
            var saludEmpleador = parametrosNomina.FirstOrDefault(t => t.Descripcion == "SALUDEMPLEADOR").ValorNumerico;
            var saludTrabajador = parametrosNomina.FirstOrDefault(t => t.Descripcion == "SALUDTRABAJADOR").ValorNumerico;
            var pensionEmpleador = parametrosNomina.FirstOrDefault(t => t.Descripcion == "PENSIONEMPLEADOR").ValorNumerico;
            var pensionTrabajador = parametrosNomina.FirstOrDefault(t => t.Descripcion == "PENSIONTRABAJADOR").ValorNumerico;
            var arl = parametrosNomina.FirstOrDefault(t => t.Descripcion == "ARL").ValorNumerico;
            var cesantias = parametrosNomina.FirstOrDefault(t => t.Descripcion == "CESANTIAS").ValorNumerico;
            var intCesantias = parametrosNomina.FirstOrDefault(t => t.Descripcion == "INT CESANTIAS").ValorNumerico;
            var vacaciones = parametrosNomina.FirstOrDefault(t => t.Descripcion == "VACACIONES").ValorNumerico;
            var cajaCompensacion = parametrosNomina.FirstOrDefault(t => t.Descripcion == "CAJACOMPENSACION").ValorNumerico;
            var icbf = parametrosNomina.FirstOrDefault(t => t.Descripcion == "ICBF").ValorNumerico;
            var sena = parametrosNomina.FirstOrDefault(t => t.Descripcion == "SENA").ValorNumerico;
            var salarioMinimo = parametrosNomina.FirstOrDefault(t => t.Descripcion == "SALARIO_MINIMO").ValorNumerico;
            var auxTransporte = parametrosNomina.FirstOrDefault(t => t.Descripcion == "AUX_TRANSPORTE").ValorNumerico;

            var diurno = parametrosHorasExtras.FirstOrDefault(t => t.Descripcion == "Diurno").ValorNumerico;
            var nocturno = parametrosHorasExtras.FirstOrDefault(t => t.Descripcion == "Nocturno").ValorNumerico;
            var diurnoFestivo = parametrosHorasExtras.FirstOrDefault(t => t.Descripcion == "Diurno_Festivo").ValorNumerico;
            var nocturnoFestivo = parametrosHorasExtras.FirstOrDefault(t => t.Descripcion == "Nocturno_Festivo").ValorNumerico;

            var ValorHora = nomina.SalarioBase / 240;
            Liquidacion newLiquidacion = new Liquidacion();
            newLiquidacion.NominaId = nomina.IdNomina;
            newLiquidacion.IdEmpleado = nomina.IdEmpleado;
            newLiquidacion.Mes = DateTime.Now.Month;
            newLiquidacion.Anio = DateTime.Now.Year;
            newLiquidacion.SueldoOrdinario = (nomina.SalarioBase / 30 * nomina.DiasTrabajados)
                + (((1 + diurno/100) * ValorHora) * nomina.HoraExtraDiurna)
                + (((1 + nocturno / 100) * ValorHora) * nomina.HoraExtraNocturna)
                + (((1 + diurnoFestivo / 100) * ValorHora) * nomina.HoraExtraDiurnaFestivo)
                + (((1 + nocturnoFestivo / 100) * ValorHora) * nomina.HoraExtraNocturnaFestivo) + nomina.Comisiones;
            newLiquidacion.SubTransporte = nomina.SalarioBase < (salarioMinimo * 2) ? auxTransporte : 0;
            newLiquidacion.Salud_Empleador = newLiquidacion.SueldoOrdinario * saludEmpleador / 100;
            newLiquidacion.Salud_Trabajador = newLiquidacion.SueldoOrdinario * saludTrabajador / 100;
            newLiquidacion.Pension_Trabajador = newLiquidacion.SueldoOrdinario * pensionTrabajador / 100;
            newLiquidacion.Pension_Empleador = newLiquidacion.SueldoOrdinario * pensionEmpleador / 100;
            newLiquidacion.TotalDevengado = nomina.SalarioBase + newLiquidacion.SubTransporte + nomina.Comisiones;
            newLiquidacion.Prima = newLiquidacion.TotalDevengado * (cesantias / 100);
            newLiquidacion.Cesantias = newLiquidacion.TotalDevengado * cesantias / 100;
            newLiquidacion.Int_Cesantias = newLiquidacion.Cesantias * intCesantias / 100;
            newLiquidacion.Vacaciones = nomina.SalarioBase * vacaciones / 100;
            newLiquidacion.Arl = newLiquidacion.SueldoOrdinario * arl / 100;
            newLiquidacion.Caja_Comp = newLiquidacion.SueldoOrdinario * cajaCompensacion / 100;
            newLiquidacion.ICBF = nomina.SalarioBase > (salarioMinimo * 10) ? (newLiquidacion.SueldoOrdinario * icbf / 100) : 0;  
            newLiquidacion.SENA = nomina.SalarioBase > (salarioMinimo * 10) ? (newLiquidacion.SueldoOrdinario * sena / 100) : 0;
            newLiquidacion.TotalDeducido = newLiquidacion.Salud_Trabajador + newLiquidacion.Pension_Trabajador;
            newLiquidacion.TotalPagar = newLiquidacion.TotalDevengado - newLiquidacion.TotalDeducido;
            IReadOnlyList<string> errors = newLiquidacion.CanCrear(newLiquidacion);
            if (errors.Any())
            {
                string listaErrors = "Errores:" + string.Join(",", errors);
                return new PagarEmpleadoResponse() { Message = listaErrors };
            }
            _unitOfWork.LiquidacionServiceRepository.Add(newLiquidacion);
            _unitOfWork.Commit();
            return new PagarEmpleadoResponse() { Message = $"Empleado Pagado Exitosamente" };
        }
    }
}
 
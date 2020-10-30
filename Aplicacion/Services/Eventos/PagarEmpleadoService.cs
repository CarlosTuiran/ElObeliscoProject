using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            var liquidacion = _unitOfWork.LiquidacionServiceRepository.FindFirstOrDefault(t => t.IdLiquidacion == request.IdNomina && t.IdEmpleado == request.IdEmpleado);
            Nomina nomina = _unitOfWork.NominaServiceRepository.FindFirstOrDefault(t => t.IdNomina == request.IdNomina && t.IdEmpleado == request.IdEmpleado);

            if (liquidacion == null)
            {
                string Day = DateTime.Now.Day.ToString();
                string Month = DateTime.Now.Month.ToString();
                string Year = DateTime.Now.Year.ToString();
                Liquidacion newLiquidacion = new Liquidacion();
                newLiquidacion.IdLiquidacion = Day + "/" + Month + "/" + Year;
                newLiquidacion.NominaId = nomina.IdNomina;
                newLiquidacion.IdEmpleado = nomina.IdEmpleado;
                newLiquidacion.SueldoOrdinario = nomina.SalarioBase * nomina.DiasTrabajados;
                newLiquidacion.SubTransporte = nomina.SubTransporte * nomina.DiasTrabajados;
                double HE = (((nomina.SalarioBase/30)/8)*1.25)*nomina.HorasExtras ;
                newLiquidacion.TotalDevengado = newLiquidacion.SueldoOrdinario + newLiquidacion.SubTransporte + HE;
                newLiquidacion.Salud = (newLiquidacion.TotalDevengado - newLiquidacion.SubTransporte) * 0.04;
                newLiquidacion.Pension = (newLiquidacion.TotalDevengado - newLiquidacion.SubTransporte) * 0.04;
                newLiquidacion.TotalDeducido = newLiquidacion.Salud + newLiquidacion.Pension;
                newLiquidacion.TotalPagar = newLiquidacion.TotalDevengado - newLiquidacion.TotalDeducido;
                IReadOnlyList<string> errors = newLiquidacion.CanCrear(newLiquidacion);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new PagarEmpleadoResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.LiquidacionServiceRepository.Add(newLiquidacion);
                    _unitOfWork.Commit();
                    return new PagarEmpleadoResponse() { Message = $"Empleado Pagado Exitosamente" };
                }
            }
            else 
            {
                return new PagarEmpleadoResponse() { Message = $"Ya le ha pagado a este empleado" };

            }
        }
    }
}
    
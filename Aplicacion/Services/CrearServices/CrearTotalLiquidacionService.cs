using Aplicacion.Request;
using Aplicacion.Services.Eventos;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Services.CrearServices
{
    public class CrearTotalLiquidacionService
    {
        readonly IUnitOfWork _unitOfWork;
        private PartidaDobleService PartidaDobleService;

        public CrearTotalLiquidacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            PartidaDobleService=new PartidaDobleService(unitOfWork);
        }

        public CrearTotalLiquidacionResponse Ejecutar()
        {
            int Month = DateTime.Now.Month;
            int Year = DateTime.Now.Year;
            string nominaid = Month + " - " + Year;
            var totalLiquidacion = _unitOfWork.TotalLiquidacionServiceRepository.FindFirstOrDefault(t => t.NominaId == nominaid && t.Mes == Month && t.Anio == Year);
            var liquidaciones = _unitOfWork.LiquidacionServiceRepository.FindBy(t => t.Anio == Year && t.Mes == Month);

            if (totalLiquidacion != null)
            {
                return new CrearTotalLiquidacionResponse() { Message = $"Ya existe el Total Liquidacion" };
            }
            if (liquidaciones == null)
            {
                return new CrearTotalLiquidacionResponse() { Message = $"No hay Liquidaciones" };
            }
            TotalLiquidacion newTotalLiquidacion = new TotalLiquidacion();
            newTotalLiquidacion.Mes = Month;
            newTotalLiquidacion.Anio = Year;
            foreach (var item in liquidaciones)
            {
                var nomina = _unitOfWork.NominaServiceRepository.FindFirstOrDefault(t => t.IdEmpleado == item.IdEmpleado && t.IdNomina == item.NominaId);
                newTotalLiquidacion.ValorTotalNomina += item.TotalPagar;
                newTotalLiquidacion.Sueldo += nomina.SalarioBase;
                newTotalLiquidacion.SubTransporte += item.SubTransporte;
                newTotalLiquidacion.TotalDevengado += item.TotalDevengado;
                newTotalLiquidacion.Comisiones += item.SueldoOrdinario - nomina.SalarioBase;
                newTotalLiquidacion.Salud_Empleador += item.Salud_Empleador;
                newTotalLiquidacion.Salud_Trabajador += item.Salud_Trabajador;
                newTotalLiquidacion.Salud += (item.Salud_Empleador + item.Salud_Trabajador);
                newTotalLiquidacion.Pension_Trabajador += item.Pension_Trabajador;
                newTotalLiquidacion.Pension_Empleador += item.Pension_Empleador;
                newTotalLiquidacion.Pension += (item.Pension_Empleador + item.Pension_Trabajador);
                newTotalLiquidacion.Prima += item.Prima;
                newTotalLiquidacion.Cesantias += item.Cesantias;
                newTotalLiquidacion.Int_Cesantias += item.Int_Cesantias;
                newTotalLiquidacion.Vacaciones += item.Vacaciones;
                newTotalLiquidacion.Arl += item.Arl;
                newTotalLiquidacion.Caja_Comp += item.Caja_Comp;
                newTotalLiquidacion.ICBF += item.ICBF;
                newTotalLiquidacion.SENA += item.SENA;
                newTotalLiquidacion.RetencionAporteNomina += (item.Salud_Empleador
                    + item.Salud_Trabajador) + item.Arl + item.Caja_Comp
                    + item.ICBF + item.SENA;
                newTotalLiquidacion.AcreedoresVarios += (item.Pension_Empleador + item.Pension_Trabajador);
                newTotalLiquidacion.Provision += item.Cesantias + item.Int_Cesantias + item.Vacaciones + item.Prima;
                newTotalLiquidacion.SalariosPagar += item.TotalDevengado - item.Salud_Trabajador - item.Pension_Trabajador;
                newTotalLiquidacion.Parafiscales += item.Caja_Comp + item.ICBF + item.SENA;
            }            
            newTotalLiquidacion.NominaId = nominaid;
            IReadOnlyList<string> errors = newTotalLiquidacion.CanCrear(newTotalLiquidacion);
            if (errors.Any())
            {
                string listaErrors = "Errores:";
                foreach (var item in errors)
                {
                    listaErrors += item.ToString();
                }
                return new CrearTotalLiquidacionResponse() { Message = listaErrors };
            }
            else
            {
                _unitOfWork.TotalLiquidacionServiceRepository.Add(newTotalLiquidacion);
                PartidaDobleService.LiquidarTotalLiquidacion(newTotalLiquidacion);
                _unitOfWork.Commit();
                return new CrearTotalLiquidacionResponse() { Message = $"Total Liquidacion Creado Exitosamente" };
            }
        }
    }
}

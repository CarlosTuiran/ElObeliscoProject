using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.CrearServices
{
    public class CrearTotalLiquidacionService
    {
        readonly IUnitOfWork _unitOfWork;
        
        public CrearTotalLiquidacionService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public CrearTotalLiquidacionResponse Ejecutar() 
        {
            int Month = DateTime.Now.Month;
            int Year = DateTime.Now.Year;
            string nominaid = Month + " - " + Year;
            var totalLiquidacion = _unitOfWork.TotalLiquidacionServiceRepository.FindFirstOrDefault(t => t.NominaId == nominaid && t.Mes == Month && t.Anio == Year);
            var liquidaciones = _unitOfWork.LiquidacionServiceRepository.FindBy(t => t.Anio == Year && t.Mes == Month);

            if (totalLiquidacion == null)
            {
                if (liquidaciones == null)
                {
                    return new CrearTotalLiquidacionResponse() { Message = $"No hay Liquidaciones" };
                }
                else
                {
                    
                    TotalLiquidacion newTotalLiquidacion=new TotalLiquidacion();
                    newTotalLiquidacion.NominaId = nominaid;
                    newTotalLiquidacion.Mes = Month;
                    newTotalLiquidacion.Anio = Year;
                    newTotalLiquidacion.CrearTotalLiquidacion(liquidaciones.ToList());
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
                        _unitOfWork.Commit();
                        return new CrearTotalLiquidacionResponse() { Message = $"Crear Total Liquidacion Exitosamente" };
                    }
                }
                
            }
            else
            {
                return new CrearTotalLiquidacionResponse() { Message = $"Ya existe el Total Liquidacion" };

            }
        }
    }
}

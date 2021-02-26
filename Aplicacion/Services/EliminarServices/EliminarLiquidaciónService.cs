using System;
using System.Collections.Generic;
using System.Text;
using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarLiquidaciónService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarLiquidaciónService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarLiquidacionResponse Ejecutar(EliminarlLiquidacionRequest request)
        {
            Liquidacion liquidacion = _unitOfWork.LiquidacionServiceRepository.FindFirstOrDefault(t => t.NominaId == request.NominaId && t.IdEmpleado == request.IdEmpleado);
            TotalLiquidacion totalLiquidacion = _unitOfWork.TotalLiquidacionServiceRepository.FindFirstOrDefault(t => t.NominaId == request.NominaId);
            if (totalLiquidacion == null)
            {
                if (liquidacion == null)
                {
                    return new EliminarLiquidacionResponse() { Message = $"Liquidacion no existe" };
                }
                else
                {
                    _unitOfWork.LiquidacionServiceRepository.Delete(liquidacion);
                    _unitOfWork.Commit();
                    return new EliminarLiquidacionResponse() { Message = $"Liquidacion Eliminado Exitosamente" };
                }
            }
            else
            {
                return new EliminarLiquidacionResponse() { Message = $"Para borrar la liquidación, primero elimine Total Liquidacion" };
            }
            
        }
    }
}

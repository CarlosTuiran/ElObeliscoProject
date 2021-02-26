using System;
using System.Collections.Generic;
using System.Text;
using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarTotalLiquidacionService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarTotalLiquidacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarTotalLiquidacionResponse Ejecutar(EliminarTotalLiquidacionRequest request)
        {
            TotalLiquidacion totalLiquidacion = _unitOfWork.TotalLiquidacionServiceRepository.FindFirstOrDefault(t => t.NominaId == request.NominaId);
            if (totalLiquidacion == null)
            {
                return new EliminarTotalLiquidacionResponse() { Message = $"Total Liquidacion no existe" };
            }
            else
            {
                _unitOfWork.TotalLiquidacionServiceRepository.Delete(totalLiquidacion);
                _unitOfWork.Commit();
                return new EliminarTotalLiquidacionResponse() { Message = $"Total Liquidacion Eliminado Exitosamente" };
            }
        }
    }
}

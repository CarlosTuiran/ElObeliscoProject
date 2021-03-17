using System;
using System.Collections.Generic;
using System.Text;
using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarNominaService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarNominaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarNominaResponse Ejecutar(EliminarNominaRequest request)
        {
            Nomina nomina = _unitOfWork.NominaServiceRepository.FindFirstOrDefault(t => t.IdNomina == request.IdNomina && t.IdEmpleado == request.IdEmpleado);
            Liquidacion liquidacion = _unitOfWork.LiquidacionServiceRepository.FindFirstOrDefault(t => t.IdEmpleado == request.IdEmpleado);
            if (liquidacion == null)
            {
                if (nomina == null)
                {
                    return new EliminarNominaResponse() { Message = $"Nomina no existe" };
                }
                else
                {
                    _unitOfWork.NominaServiceRepository.Delete(nomina);
                    _unitOfWork.Commit();
                    return new EliminarNominaResponse() { Message = $"Nomina Eliminado Exitosamente" };
                }
            }
            else
            {
                return new EliminarNominaResponse() { Message = $"Para borrar nomina, primero elimine Liquidacion" };
            }
            
        }
    }
}

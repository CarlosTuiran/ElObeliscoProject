using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarNominaService
    {
        readonly IUnitOfWork _unitOfWork;

        public ActualizarNominaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarNominaResponse Ejecutar(ActualizarNominaRequest request)
        {
            Nomina nomina = _unitOfWork.NominaServiceRepository.FindFirstOrDefault(t => t.IdEmpleado == request.IdEmpleado);
            if (nomina == null)
            {
                return new ActualizarNominaResponse() { Message = $"Empleado no existe" };
            }
            else
            {
                nomina.IdEmpleado = request.IdEmpleado;
                nomina.SaldoBase = request.SaldoBase;
                
                
                nomina.Seguro = request.Seguro;
                _unitOfWork.NominaServiceRepository.Edit(nomina);
                _unitOfWork.Commit();
                return new ActualizarNominaResponse() { Message = $"Empleado de nomina actualizado Exitosamente" };
            }
        }
    }
}

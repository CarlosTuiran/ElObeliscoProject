using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarCuentaService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarCuentaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarCuentaResponse Ejecutar(ActualizarCuentaRequest request)
        {
            Cuenta cuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (cuenta == null)
            {
                return new ActualizarCuentaResponse() { Message = $"Cuenta no existe" };
            }
            else
            {
                cuenta.Codigo = request.Codigo;
                cuenta.Naturaleza = request.Naturaleza;
                cuenta.Nombre = request.Nombre;
                cuenta.Clase = request.Clase;
                _unitOfWork.CuentaServiceRepository.Edit(cuenta);
                _unitOfWork.Commit();
                return new ActualizarCuentaResponse() { Message = $"Cuenta Actualizada Exitosamente" };
            }
        }
    }
}

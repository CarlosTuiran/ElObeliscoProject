using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarCuentaService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarCuentaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarCuentaResponse Ejecutar(int id)
        {
            Cuenta cuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Id == id);
            if (cuenta == null)
            {
                return new EliminarCuentaResponse() { Message = $"Cuenta no existe" };
            }
            else
            {
                _unitOfWork.CuentaServiceRepository.Delete(cuenta);
                _unitOfWork.Commit();
                return new EliminarCuentaResponse() { Message = $"Cuenta Eliminada Exitosamente" };
            }
        }
    }
}

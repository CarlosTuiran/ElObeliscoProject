using System;
using System.Collections.Generic;
using System.Text;
using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarTerceroService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarTerceroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarTerceroResponse Ejecutar(EliminarTerceroRequest request)
        {
            Terceros terceros = _unitOfWork.TercerosServiceRepository.FindFirstOrDefault(t => t.Nit == request.Nit);
            if (terceros == null)
            {
                return new EliminarTerceroResponse() { Message = $"Empleado no existe" };
            }
            else
            {
                terceros.Estado = "Inactivo";
                _unitOfWork.TercerosServiceRepository.Edit(terceros);
                _unitOfWork.Commit();
                return new EliminarTerceroResponse() { Message = $"Empleado Eliminado Exitosamente" };
            }
        }
    }
}

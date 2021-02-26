using System;
using System.Collections.Generic;
using System.Text;
using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarEmpleadoService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarEmpleadoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarEmpleadoResponse Ejecutar(EliminarEmpleadoRequest request)
        {
            Empleado empleado = _unitOfWork.EmpleadoServiceRepository.FindFirstOrDefault(t => t.IdEmpleado == request.IdEmpleado);
            if (empleado == null)
            {
                return new EliminarEmpleadoResponse() { Message = $"Empleado no existe" };
            }
            else
            {
                empleado.IdEmpleado = request.IdEmpleado;
                empleado.Estado = "Inactivo";
                _unitOfWork.EmpleadoServiceRepository.Edit(empleado);
                _unitOfWork.Commit();
                return new EliminarEmpleadoResponse() { Message = $"Empleado Eliminado Exitosamente" };
            }
        }
    }
}

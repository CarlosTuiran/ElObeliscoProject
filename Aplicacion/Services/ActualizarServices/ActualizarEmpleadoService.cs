using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarEmpleadoService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarEmpleadoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarEmpleadoResponse Ejecutar(ActualizarEmpleadoRequest request)
        {
            Empleado empleado = _unitOfWork.EmpleadoServiceRepository.FindFirstOrDefault(t => t.IdEmpleado == request.IdEmpleado);
            if (empleado == null)
            {
                return new ActualizarEmpleadoResponse() { Message = $"Empleado no existe" };
            }
            else
            {
                empleado.IdEmpleado = request.IdEmpleado;
                empleado.Nombres = request.Nombres;
                empleado.Apellidos = request.Apellidos;
                empleado.Cargo = request.Cargo;
                empleado.Celular = request.Celular;
                empleado.Correo = request.Correo;
                empleado.Direccion = request.Direccion;
                empleado.Estado = request.Estado;
                _unitOfWork.EmpleadoServiceRepository.Edit(empleado);
                _unitOfWork.Commit();
                return new ActualizarEmpleadoResponse() { Message = $"Empleado Actualizado Exitosamente" };
            }
        }
    }
}

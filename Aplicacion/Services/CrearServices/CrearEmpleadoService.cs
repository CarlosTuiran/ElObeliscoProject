using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Aplicacion.Request.CrearEmpleadoRequest;

namespace Aplicacion.Services.CrearServices
{
    public class CrearEmpleadoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearEmpleadoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearEmpleadoResponse Ejecutar(CrearEmpleadoRequest request)
        {

            var empleado = _unitOfWork.EmpleadoServiceRepository.FindFirstOrDefault(t => t.IdEmpleado == request.IdEmpleado);
            if (empleado == null)
            {
                Empleado newEmpleado = new Empleado(request.IdEmpleado, request.Nombres, request.Apellidos, request.Cargo, request.Celular, 
                request.Correo, request.Direccion, request.Estado, request.FechaIngreso);
                IReadOnlyList<string> errors = newEmpleado.CanCrear(newEmpleado);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearEmpleadoResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.EmpleadoServiceRepository.Add(newEmpleado);
                    _unitOfWork.Commit();
                    return new CrearEmpleadoResponse() { Message = $"Empleado Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearEmpleadoResponse() { Message = $"Empleado ya existe" };
            }
        }
    }
}

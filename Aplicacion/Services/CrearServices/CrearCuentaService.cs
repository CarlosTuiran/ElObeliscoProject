using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

namespace Aplicacion.Services.CrearServices
{
    public class CrearCuentaService
    {
        readonly IUnitOfWork _unitOfWork;
        public CrearCuentaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearCuentaResponse Ejecutar(CrearCuentaRequest request)
        {
            var cuenta = _unitOfWork.CuentaServiceRepository.FindFirstOrDefault(t => t.Codigo == request.Codigo);
            if (cuenta == null)
            {
                Cuenta newCuenta = new Cuenta(request.Codigo,request.Nombre, request.Naturaleza, request.Clase);
                IReadOnlyList<string> errors = newCuenta.CanCrear(newCuenta);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearCuentaResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.CuentaServiceRepository.Add(newCuenta);
                    _unitOfWork.Commit();
                    return new CrearCuentaResponse() { Message = $"Cuenta Creada Exitosamente" };
                }
            }
            else
            {
                return new CrearCuentaResponse() { Message = $"Cuenta ya existe" };
            }
        }
    }
}

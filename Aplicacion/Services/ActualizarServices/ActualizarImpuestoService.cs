using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarImpuestoService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarImpuestoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarImpuestoResponse Ejecutar(ActualizarImpuestoRequest request)
        {
            Impuesto impuesto = _unitOfWork.ImpuestoServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (impuesto == null)
            {
                return new ActualizarImpuestoResponse($"Impuesto no existe");
            }
            impuesto.Nombre = request.Nombre;
            impuesto.Tarifa = request.Tarifa;
            impuesto.Tipo = request.Tipo;
            impuesto.Activo = request.Activo;
            _unitOfWork.ImpuestoServiceRepository.Edit(impuesto);
            _unitOfWork.Commit();
            return new ActualizarImpuestoResponse($"Impuesto Actualizado Exitosamente");
        }
    }
}

using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarBodegaService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarBodegaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarBodegaResponse Ejecutar(BodegaRequest request)
        {
            Bodega bodega = _unitOfWork.BodegaServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (bodega == null)
            {
                return new ActualizarBodegaResponse($"Bodega no existe");
            }
            bodega.Nombre = request.Nombre;
            _unitOfWork.BodegaServiceRepository.Edit(bodega);
            _unitOfWork.Commit();
            return new ActualizarBodegaResponse($"Bodega Actualizado Exitosamente");
        }
    }
}

using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarBodegaService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarBodegaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarBodegaResponse Ejecutar(int id)
        {
            Bodega bodega = _unitOfWork.BodegaServiceRepository.FindFirstOrDefault(t => t.Id == id);
            if (bodega == null)
            {
                return new EliminarBodegaResponse($"Bodega no existe");
            }
            _unitOfWork.BodegaServiceRepository.Delete(bodega);
            _unitOfWork.Commit();
            return new EliminarBodegaResponse($"Bodega Elimiado Exitosamente");
        }
    }
}

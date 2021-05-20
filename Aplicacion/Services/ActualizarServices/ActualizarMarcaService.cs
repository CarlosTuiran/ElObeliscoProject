using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarMarcaService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarMarcaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarMarcaResponse Ejecutar(ActualizarMarcaRequest request)
        {
            Marca marca = _unitOfWork.MarcaServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (marca == null)
            {
                return new ActualizarMarcaResponse($"Marca no existe");
            }
            marca.Nombre = request.Nombre;
            _unitOfWork.MarcaServiceRepository.Edit(marca);
            _unitOfWork.Commit();
            return new ActualizarMarcaResponse($"Marca Actualizada Exitosamente");
        }
    }
}

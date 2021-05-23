using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarImpuestoService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarImpuestoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarImpuestoResponse Ejecutar(int id)
        {
            Impuesto impuesto = _unitOfWork.ImpuestoServiceRepository.FindFirstOrDefault(t => t.Id == id);
            if (impuesto == null)
            {
                return new EliminarImpuestoResponse($"Impuesto no existe");
            }
            _unitOfWork.ImpuestoServiceRepository.Delete(impuesto);
            _unitOfWork.Commit();
            return new EliminarImpuestoResponse($"Impuesto Eliminado Exitosamente");
        }
    }
}

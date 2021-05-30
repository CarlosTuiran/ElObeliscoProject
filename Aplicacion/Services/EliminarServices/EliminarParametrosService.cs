using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarParametrosService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarParametrosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarParametrosResponse Ejecutar(int id)
        {
            Parametros Parametros = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Id == id);
            if (Parametros == null)
            {
                return new EliminarParametrosResponse() { Message = $"Parametro no existe" };
            }
            else
            {
                _unitOfWork.ParametrosServiceRepository.Delete(Parametros);
                _unitOfWork.Commit();
                return new EliminarParametrosResponse() { Message = $"Parametro Eliminado Exitosamente" };
            }
        }
    }
}

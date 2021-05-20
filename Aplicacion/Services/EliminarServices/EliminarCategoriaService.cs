using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarCategoriaService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarCategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarCategoriaResponse Ejecutar(int id)
        {
            Categoria categoria = _unitOfWork.CategoriaServiceRepository.FindFirstOrDefault(t => t.Id == id);
            if (categoria == null)
            {
                return new EliminarCategoriaResponse($"Categoría no existe");
            }
            _unitOfWork.CategoriaServiceRepository.Delete(categoria);
            _unitOfWork.Commit();
            return new EliminarCategoriaResponse($"Categoría Eliminada Exitosamente");
        }
    }
}

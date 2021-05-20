using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarCategoriaService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarCategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarCategoriaResponse Ejecutar(ActualizarCategoriaRequest request)
        {
            Categoria categoria = _unitOfWork.CategoriaServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (categoria == null)
            {
                return new ActualizarCategoriaResponse($"Categoria no existe");
            }
            categoria.Nombre = request.Nombre;
            _unitOfWork.CategoriaServiceRepository.Edit(categoria);
            _unitOfWork.Commit();
            return new ActualizarCategoriaResponse($"Categoria Actualizada Exitosamente");
        }
    }
}

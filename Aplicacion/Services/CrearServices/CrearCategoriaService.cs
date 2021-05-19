using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Services.CrearServices
{
    public class CrearCategoriaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearCategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearCategoriaResponse Ejecutar(CrearCategoriaRequest request)
        {
            var categoria = _unitOfWork.CategoriaServiceRepository.FindFirstOrDefault(t => t.Nombre == request.Nombre);
            if (categoria != null)
            {
                return new CrearCategoriaResponse($"Categoria ya existe");
            }
            Categoria newCategoria = new Categoria(request.Nombre);
            IReadOnlyList<string> errors = newCategoria.CanCrear(newCategoria);
            if (errors.Any())
            {
                string listaErrors = "Errores:" + string.Join(",", errors);
                return new CrearCategoriaResponse(listaErrors);
            }
            _unitOfWork.CategoriaServiceRepository.Add(newCategoria);
            _unitOfWork.Commit();
            return new CrearCategoriaResponse($"Cuenta Creada Exitosamente");
        }
    }
}

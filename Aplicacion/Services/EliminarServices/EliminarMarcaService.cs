using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarMarcaService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarMarcaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarMarcaResponse Ejecutar(int id)
        {
            Marca marca = _unitOfWork.MarcaServiceRepository.FindFirstOrDefault(t => t.Id == id);
            if (marca == null)
            {
                return new EliminarMarcaResponse($"Marca no existe");
            }
            _unitOfWork.MarcaServiceRepository.Delete(marca);
            _unitOfWork.Commit();
            return new EliminarMarcaResponse($"Marca Eliminada Exitosamente");
        }
    }
}

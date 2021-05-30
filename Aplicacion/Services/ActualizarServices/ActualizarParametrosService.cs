using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;


namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarParametrosService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarParametrosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarParametrosResponse Ejecutar(ActualizarParametrosRequest request)
        {
            Parametros Parametros = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Id == request.Id);
            if (Parametros == null)
            {
                return new ActualizarParametrosResponse() { Message = $"Parametro no existe" };
            }
            else
            {
                Parametros.Agrupacion = request.Agrupacion;
                Parametros.ValorNumerico = request.ValorNumerico;
                Parametros.ValorTxt = request.ValorTxt;
                Parametros.Descripcion = request.Descripcion;
                _unitOfWork.ParametrosServiceRepository.Edit(Parametros);
                _unitOfWork.Commit();
                return new ActualizarParametrosResponse() { Message = $"Parametro Actualizado Exitosamente" };
            }
        }
    }
}

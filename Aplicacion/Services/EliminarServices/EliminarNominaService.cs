using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarNominaService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarNominaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarNominaResponse Ejecutar(EliminarNominaRequest request)
        {            
            Liquidacion liquidacion = _unitOfWork.LiquidacionServiceRepository.FindFirstOrDefault(t => t.IdEmpleado == request.IdEmpleado);
            if (liquidacion != null)
            {
                return new EliminarNominaResponse() { Message = $"Para borrar nomina, primero elimine Liquidacion" };
            }
            Nomina nomina = _unitOfWork.NominaServiceRepository.FindFirstOrDefault(t => t.IdNomina == request.IdNomina && t.IdEmpleado == request.IdEmpleado);
            if (nomina == null)
            {
                return new EliminarNominaResponse() { Message = $"Nomina no existe" };
            }
            _unitOfWork.NominaServiceRepository.Delete(nomina);
            _unitOfWork.Commit();
            return new EliminarNominaResponse() { Message = $"Nomina Eliminado Exitosamente" };
        }
    }
}

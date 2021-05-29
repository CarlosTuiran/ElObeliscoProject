using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarNominaService
    {
        readonly IUnitOfWork _unitOfWork;

        public ActualizarNominaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarNominaResponse Ejecutar(ActualizarNominaRequest request)
        {
            Nomina nomina = _unitOfWork.NominaServiceRepository.FindFirstOrDefault(t => t.IdNomina == request.IdNomina && t.IdEmpleado == request.IdEmpleado);
            if (nomina == null)
            {
                return new ActualizarNominaResponse() { Message = $"Empleado en Nomina no existe" };
            }
            nomina.DiasTrabajados = request.DiasTrabajados;
            nomina.HoraExtraDiurna = request.HoraExtraDiurna;
            nomina.HoraExtraNocturna = request.HoraExtraNocturna;
            nomina.HoraExtraDiurnaFestivo = request.HoraExtraDiurnaFestivo;
            nomina.HoraExtraNocturnaFestivo = request.HoraExtraNocturnaFestivo;
            nomina.SalarioBase = request.SalarioBase;
            _unitOfWork.NominaServiceRepository.Edit(nomina);
            _unitOfWork.Commit();
            return new ActualizarNominaResponse() { Message = $"Empleado en Nomina Actualizado Exitosamente" };
        }
    }
}

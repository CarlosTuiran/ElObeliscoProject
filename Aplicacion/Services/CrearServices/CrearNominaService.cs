using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Services.CrearServices
{
    public class CrearNominaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearNominaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearNominaResponse Ejecutar(CrearNominaRequest request)
        {

            var nomina = _unitOfWork.NominaServiceRepository.FindFirstOrDefault(t => t.IdNomina == request.IdNomina && t.IdEmpleado == request.IdEmpleado);
            if (nomina != null)
            {
                return new CrearNominaResponse() { Message = $"Empleado en Nomina ya existe" };
            }
            Nomina newNomina = new Nomina(request.IdNomina, request.IdEmpleado, request.DiasTrabajados,
                request.HoraExtraDiurna, request.HoraExtraNocturna, request.HoraExtraDiurnaFestivo,
                request.HoraExtraNocturnaFestivo, request.SalarioBase);
            IReadOnlyList<string> errors = newNomina.CanCrear(newNomina);
            if (errors.Any())
            {
                string listaErrors = "Errores:" + string.Join(",", errors);
                return new CrearNominaResponse() { Message = listaErrors };
            }
            _unitOfWork.NominaServiceRepository.Add(newNomina);
            _unitOfWork.Commit();
            return new CrearNominaResponse() { Message = $"Empleado en Nomina Creado Exitosamente" };
        }
    }
}

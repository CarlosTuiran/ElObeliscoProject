using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.Eventos
{
    public class PagarEmpleadoService
    {
        readonly IUnitOfWork _unitOfWork;
        public PagarEmpleadoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagarEmpleadoResponse Ejecutar(PagarEmpleadoRequest request)
        {

            var liquidacion = _unitOfWork.LiquidacionServiceRepository.FindFirstOrDefault(t => t.NominaId == request.IdNomina && t.IdEmpleado == request.IdEmpleado);
            var nomina = _unitOfWork.NominaServiceRepository.FindFirstOrDefault(t => t.IdEmpleado == request.IdEmpleado);

            if (liquidacion == null)
            {
                Liquidacion newLiquidacion = new Liquidacion();
                newLiquidacion.CalculoLiquidacion(nomina);
                IReadOnlyList<string> errors = newLiquidacion.CanCrear(newLiquidacion);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new PagarEmpleadoResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.LiquidacionServiceRepository.Add(newLiquidacion);
                    _unitOfWork.Commit();
                    return new PagarEmpleadoResponse() { Message = $"Empleado Pagado Exitosamente" };
                }
            }
            else 
            {
                return new PagarEmpleadoResponse() { Message = $"Ya le ha pagado a este empleado" };
            }
        }
    }
}
 
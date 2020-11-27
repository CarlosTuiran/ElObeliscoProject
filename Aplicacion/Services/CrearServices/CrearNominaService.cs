using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Aplicacion.Request.CrearNominaRequest;

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
            if (nomina == null)
            {
                Nomina newNomina = new Nomina(request.IdNomina, request.IdEmpleado, request.DiasTrabajados, request.HorasExtras,request.SalarioBase, request.SubTransporte);
                IReadOnlyList<string> errors = newNomina.CanCrear(newNomina);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearNominaResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.NominaServiceRepository.Add(newNomina);
                    _unitOfWork.Commit();
                    return new CrearNominaResponse() { Message = $"Empleado en Nomina Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearNominaResponse() { Message = $"Empleado en Nomina ya existe" };
            }
        }
    }
}

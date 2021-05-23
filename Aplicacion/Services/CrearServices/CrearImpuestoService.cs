using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.CrearServices
{
    public class CrearImpuestoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearImpuestoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearImpuestoResponse Ejecutar(CrearImpuestoRequest request)
        {
            var categoria = _unitOfWork.ImpuestoServiceRepository.FindFirstOrDefault(t => t.Nombre == request.Nombre);
            if (categoria != null)
            {
                return new CrearImpuestoResponse($"Impuesto ya existe");
            }
            Impuesto newImpuesto = new Impuesto(request.Nombre, request.Tarifa, request.Tipo, request.Activo);
            IReadOnlyList<string> errors = newImpuesto.CanCrear(newImpuesto);
            if (errors.Any())
            {
                string listaErrors = "Errores:" + string.Join(",", errors);
                return new CrearImpuestoResponse(listaErrors);
            }
            _unitOfWork.ImpuestoServiceRepository.Add(newImpuesto);
            _unitOfWork.Commit();
            return new CrearImpuestoResponse($"Impuesto Creado Exitosamente");
        }
    }
}

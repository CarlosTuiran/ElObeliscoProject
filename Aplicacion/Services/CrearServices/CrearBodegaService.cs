using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.CrearServices
{
    public class CrearBodegaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearBodegaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearBodegaResponse Ejecutar(BodegaRequest request)
        {
            var bodega = _unitOfWork.BodegaServiceRepository.FindFirstOrDefault(t => t.Nombre == request.Nombre);
            if (bodega != null)
            {
                return new CrearBodegaResponse($"Bodega ya existe");
            }
            Bodega newBodega = new Bodega(request.Nombre);
            IReadOnlyList<string> errors = newBodega.CanCrear(newBodega);
            if (errors.Any())
            {
                string listaErrors = "Errores:" + string.Join(",", errors);
                return new CrearBodegaResponse(listaErrors);
            }
            _unitOfWork.BodegaServiceRepository.Add(newBodega);
            _unitOfWork.Commit();
            return new CrearBodegaResponse($"Bodega Creado Exitosamente");
        }
    }
}

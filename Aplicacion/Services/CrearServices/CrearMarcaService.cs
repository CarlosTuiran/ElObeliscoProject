using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.CrearServices
{
    public class CrearMarcaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearMarcaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearMarcaResponse Ejecutar(CrearMarcaRequest request)
        {
            var marca = _unitOfWork.MarcaServiceRepository.FindFirstOrDefault(t => t.Nombre == request.Nombre);
            if (marca != null)
            {
                return new CrearMarcaResponse($"Marca ya existe");
            }
            Marca newMarca = new Marca(request.Nombre);
            IReadOnlyList<string> errors = newMarca.CanCrear(newMarca);
            if (errors.Any())
            {
                string listaErrors = "Errores:" + string.Join(",", errors);
                return new CrearMarcaResponse(listaErrors);
            }
            _unitOfWork.MarcaServiceRepository.Add(newMarca);
            _unitOfWork.Commit();
            return new CrearMarcaResponse($"Marca Creada Exitosamente");
        }
    }
}

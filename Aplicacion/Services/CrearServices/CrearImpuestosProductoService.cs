using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.CrearServices
{
    public class CrearImpuestosProductoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearImpuestosProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearImpuestosProductoResponse Ejecutar(List<int> requests, string IdProducto)
        {
            foreach (var idImpuesto in requests)
            {
                var impuestosProductos = _unitOfWork.ImpuestosProductoServiceRepository.FindFirstOrDefault(t => t.IdProducto == IdProducto && t.IdImpuesto == idImpuesto);
                if (impuestosProductos != null)
                {
                    return new CrearImpuestosProductoResponse($"Impuestos/devengados ya existe");
                }
                ImpuestosProducto newImpuestosProducto = new ImpuestosProducto(IdProducto, idImpuesto);
                IReadOnlyList<string> errors = newImpuestosProducto.CanCrear(newImpuestosProducto);
                if (errors.Any())
                {
                    string listaErrors = "Errores:" + string.Join(",", errors);
                    return new CrearImpuestosProductoResponse(listaErrors);
                }
                _unitOfWork.ImpuestosProductoServiceRepository.Add(newImpuestosProducto);
            }
            return new CrearImpuestosProductoResponse($"Impuestos/devengados Creados Exitosamente");
        }
    }
}

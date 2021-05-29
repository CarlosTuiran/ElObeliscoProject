using Aplicacion.Request;
using Aplicacion.Services.CrearServices;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarImpuestosProductosService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly CrearImpuestosProductoService _crearImpuestosProducto;
        public ActualizarImpuestosProductosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _crearImpuestosProducto = new CrearImpuestosProductoService(_unitOfWork);
        }

        public ActualizarImpuestosProductoResponse Ejecutar(string idProducto, List<int> impuestos)
        {
            var impuestosProducto = _unitOfWork.ImpuestosProductoServiceRepository.FindBy(t => t.IdProducto == idProducto);
            if (impuestosProducto == null)
            {
                return new ActualizarImpuestosProductoResponse($"Impuestos del producto no existen");
            }
            foreach (var item in impuestosProducto)
            {
                _unitOfWork.ImpuestosProductoServiceRepository.Delete(item);
            }
            var respuestaCrear = _crearImpuestosProducto.Ejecutar(impuestos, idProducto);
            if (respuestaCrear.IsOk())
            {
                return new ActualizarImpuestosProductoResponse($"Impuestos/devengados Actualizados Exitosamente");
            }
            return new ActualizarImpuestosProductoResponse($"Error al actualizar impuestos");
        }
    }
}

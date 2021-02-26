using System;
using System.Collections.Generic;
using System.Text;
using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarProductoService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarProductoResponse Ejecutar(EliminarProductoRequest request)
        {
            Producto producto = _unitOfWork.ProductoServiceRepository.FindFirstOrDefault(t => t.Referencia == request.Referencia);
            if (producto == null)
            {
                return new EliminarProductoResponse() { Message = $"Producto no existe" };
            }
            else
            {
                producto.Estado = "Inactivo";
                _unitOfWork.ProductoServiceRepository.Edit(producto);
                _unitOfWork.Commit();
                return new EliminarProductoResponse() { Message = $"Producto Eliminado Exitosamente" };
            }
        }
    }
}

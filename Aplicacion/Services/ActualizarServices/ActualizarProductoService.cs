using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarProductoService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarProductoResponse Ejecutar(ActualizarProductoRequest request)
        {
            Producto producto = _unitOfWork.ProductoServiceRepository.FindFirstOrDefault(t => t.Referencia == request.Referencia);
            if (producto == null)
            {
                return new ActualizarProductoResponse() { Message = $"Producto no existe" };
            }
            else
            {
                producto.Costo = request.Costo;
                producto.Descripcion = request.Descripcion;
                producto.Fabrica = request.Fabrica;
                producto.FechaRegistro = DateTime.Now;
                producto.FormatoVenta = request.FormatoVenta;
                producto.IVA = request.IVA;
                producto.Marca = request.Marca;
                producto.PrecioVenta = request.PrecioVenta;
                producto.Referencia = request.Referencia;
                producto.CantidadMinima = request.CantidadMinima;
                _unitOfWork.ProductoServiceRepository.Edit(producto);
                _unitOfWork.Commit();
                return new ActualizarProductoResponse() { Message = $"Producto Actualizado Exitosamente" };
            }
        }
    }
}

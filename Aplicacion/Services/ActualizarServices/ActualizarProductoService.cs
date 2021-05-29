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
        readonly ActualizarImpuestosProductosService _actualizarImpuestosProductos;
        public ActualizarProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _actualizarImpuestosProductos = new ActualizarImpuestosProductosService(_unitOfWork);
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
                producto.Referencia = request.Referencia;
                producto.Descripcion = request.Descripcion;
                producto.FormatoVenta = request.FormatoVenta;
                producto.IdMarca = request.IdMarca;
                producto.IdCategoria = request.IdCategoria;
                producto.IdProveedor = request.IdProveedor;
                producto.Fabrica = request.Fabrica;
                producto.Costo = request.Costo;
                producto.PrecioVenta = request.PrecioVenta;
                producto.CantidadMinima = request.CantidadMinima;
                producto.FechaRegistro = request.FechaRegistro;
                producto.Estado = request.Estado;
                producto.CuentaIngreso= request.CuentaIngreso;
                producto.CuentaDevolucion= request.CuentaDevolucion;
                var respuestaActualizarImpuestosProducto = _actualizarImpuestosProductos.Ejecutar(producto.Referencia, request.IdImpuestos);
                if (respuestaActualizarImpuestosProducto.IsOk())
                {
                    _unitOfWork.ProductoServiceRepository.Edit(producto);
                    _unitOfWork.Commit();
                    return new ActualizarProductoResponse() { Message = $"Producto Actualizado Exitosamente" };
                }
                return new ActualizarProductoResponse() { Message = $"Error al actualizar el producto" };
            }
        }
    }
}

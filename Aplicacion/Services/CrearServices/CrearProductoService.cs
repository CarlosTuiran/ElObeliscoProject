using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Services.CrearServices
{
    public class CrearProductoService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly CrearImpuestosProductoService _crearImpuestosProductoService;

        public CrearProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _crearImpuestosProductoService = new CrearImpuestosProductoService(_unitOfWork);
        }

        public CrearProductoResponse Ejecutar(CrearProductoRequest request)
        {
            var producto = _unitOfWork.ProductoServiceRepository.FindFirstOrDefault(t => t.Referencia == request.Referencia);
            if (producto != null)
            {
                return new CrearProductoResponse() { Message = $"Producto ya existe revise la referencia de este" };
            }
            Producto newProducto = new Producto(request.Referencia, request.Descripcion, request.FormatoVenta,
                    request.IdMarca, request.IdCategoria, request.IdProveedor, request.Fabrica, request.Costo,
                    request.PrecioVenta, request.CantidadMinima, request.FechaRegistro, request.Estado
                    , request.CuentaIngreso, request.CuentaDevolucion);
            IReadOnlyList<string> errors = newProducto.CanCrear(newProducto);
            if (errors.Any())
            {
                string listaErrors = "Errores:" + string.Join(",", errors);
                return new CrearProductoResponse() { Message = listaErrors };
            }
            var respuesta = _crearImpuestosProductoService.Ejecutar(request.IdImpuestos, request.Referencia);
            _unitOfWork.ProductoServiceRepository.Add(newProducto);
            if (respuesta.IsOk())
            {
                _unitOfWork.Commit();
                return new CrearProductoResponse() { Message = $"Producto Creado Exitosamente" };
            }
            return new CrearProductoResponse() { Message = $"Error al crear el producto" };
        }
    }
}

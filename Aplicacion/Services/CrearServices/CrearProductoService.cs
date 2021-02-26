using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.CrearServices
{
    public class CrearProductoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearProductoResponse Ejecutar(CrearProductoRequest request)
        {

            var producto = _unitOfWork.ProductoServiceRepository.FindFirstOrDefault(t => t.Referencia == request.Referencia);
            if (producto == null)
            {
                Producto newProducto = new Producto(request.Referencia, request.Descripcion, request.FormatoVenta, request.Marca, request.Fabrica, request.Costo, request.PrecioVenta, request.IVA, request.CantidadMinima, request.Estado);
                IReadOnlyList<string> errors = newProducto.CanCrear(newProducto);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearProductoResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.ProductoServiceRepository.Add(newProducto);
                    _unitOfWork.Commit();
                    return new CrearProductoResponse() { Message = $"Producto Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearProductoResponse() { Message = $"Producto ya existe revise la referencia de este" };
            }
        }
    }
}

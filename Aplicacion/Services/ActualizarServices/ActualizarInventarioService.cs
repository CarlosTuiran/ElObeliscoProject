using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Aplicacion.Request.ActualizarInventarioRequest;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarInventarioService
    {
        readonly IUnitOfWork _unitOfWork;

        public ActualizarInventarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarInventarioResponse Ejecutar(ActualizarInventarioRequest request)
        {
            Inventario inventario = _unitOfWork.InventarioServiceRepository.FindFirstOrDefault(t => t.Referencia == request.Referencia);
            if (inventario == null)
            {
                Inventario newInventario = new Inventario(request.Referencia, request.Cantidad, request.Bodega);
                IReadOnlyList<string> errors = newInventario.CanCrear(newInventario);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new ActualizarInventarioResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.InventarioServiceRepository.Add(newInventario);
                    _unitOfWork.Commit();
                    return new ActualizarInventarioResponse() { Message = $"Producto de inventario Creado Exitosamente" };
                }
            }
            else
            {
                inventario.Cantidad += request.Cantidad;
                _unitOfWork.InventarioServiceRepository.Edit(inventario);
                _unitOfWork.Commit();
                return new ActualizarInventarioResponse() { Message = $"Producto actualizado Exitosamente" };
            }
        }
    }
}

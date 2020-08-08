using Aplicacion.Request;
using Aplicacion.Services.ActualizarServices;
using Aplicacion.Services.CrearServices;
using Domain.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.Eventos
{
    public class ComprarProductoService
    {
        readonly IUnitOfWork _unitOfWork;
        private ActualizarInventarioService actualizarInventarioService;
        public ComprarProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            actualizarInventarioService = new ActualizarInventarioService(_unitOfWork);
        }
        public ComprarProductoResponse Ejecutar(ComprarProductoRequest request)
        {
            var dFactura = _unitOfWork.DFacturaServiceRepository.FindBy(t => t.MfacturaId == request.idMfactura);
            if (dFactura != null)
            {
                //cada producto en detalles de factura 
                foreach (var dproducto in dFactura)
                {
                    var producto = _unitOfWork.ProductoServiceRepository.FindFirstOrDefault(t => t.Referencia == dproducto.Referencia);
                    if (producto == null)
                    {
                        //si no existe el producto
                        return new ComprarProductoResponse() { Message = $"Error la siguiente referencia a un producto no existe: " + dproducto.Referencia };
                    }
                    else
                    {
                        //si ya existe
                        ActualizarInventarioRequest actualizarInventarioRequest = new ActualizarInventarioRequest();
                        actualizarInventarioRequest.Referencia = dproducto.Referencia;
                        actualizarInventarioRequest.Cantidad = dproducto.Cantidad;
                        actualizarInventarioRequest.Bodega = dproducto.Bodega;
                        var rtaActualizar = actualizarInventarioService.Ejecutar(actualizarInventarioRequest);
                        if (rtaActualizar.isOk())
                        {
                            //No hubo problemas al actualizar
                        }
                        else
                        {
                            //Hubo Problemas al actualizar
                            return new ComprarProductoResponse() { Message = $"Error al actualizar " + rtaActualizar.Message };

                        }
                    }        
                }
                return new ComprarProductoResponse() { Message = $"Compra Realizada Correctamente " };

            }
            else
            {
                return new ComprarProductoResponse() { Message = $"Error no hay Detalles de Factura" };

            }
        }
    }
}

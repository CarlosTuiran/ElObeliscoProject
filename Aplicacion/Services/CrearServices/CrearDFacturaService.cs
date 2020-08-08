using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Aplicacion.Services.CrearServices
{
    public class CrearDFacturaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearDFacturaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearDFacturaResponse Ejecutar(CrearDFacturaRequest request)
        {

            var dFactura = _unitOfWork.DFacturaServiceRepository.FindFirstOrDefault(t => t.idDFactura == request.idDFactura);
            if (dFactura == null)
            {
                DFactura newDFactura = new DFactura(request.idDFactura, request.MfacturaId, request.Referencia, request.PromocionId, request.Bodega, request.Cantidad, request.PrecioUnitario);
                IReadOnlyList<string> errors = newDFactura.CanCrear(newDFactura);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearDFacturaResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.DFacturaServiceRepository.Add(newDFactura);
                    _unitOfWork.Commit();
                    return new CrearDFacturaResponse() { Message = $"Detalle de Facturas Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearDFacturaResponse() { Message = $"Detalle de Factura ya existe" };
            }
        }
    }
}

﻿using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Aplicacion.Request.CrearMFacturaRequest;

namespace Aplicacion.Services.CrearServices
{
    class CrearMFacturaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearMFacturaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearMFacturaResponse Ejecutar(CrearMFacturaRequest request)
        {

            var dFactura = _unitOfWork.MFacturaServiceRepository.FindFirstOrDefault(t => t.idMfactura == request.idMfactura);
            if (dFactura == null)
            {
                MFactura newMFactura = new MFactura(request.idMfactura, request.idEmpleado, request.Nit, request.idMovimiento, request.TipoMovimiento, request.FechaFactura,
                request.FechaPago, request.SubTotal, request.ValorDevolucion, request.Descuento, request.IVA, request.Total, request.Abono, request.EstadoFactura);
                IReadOnlyList<string> errors = newMFactura.CanCrear(newMFactura);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearMFacturaResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.MFacturaServiceRepository.Add(newMFactura);
                    _unitOfWork.Commit();
                    return new CrearMFacturaResponse() { Message = $"Factura Creada Exitosamente" };
                }
            }
            else
            {
                return new CrearMFacturaResponse() { Message = $"Factura ya existe" };
            }
        }
    }
}
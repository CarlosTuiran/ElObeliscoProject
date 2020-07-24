using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Aplicacion.Request.CrearTipoMovimientoRequest;

namespace Aplicacion.Services.CrearServices
{
    class CrearTipoMovimientoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearTipoMovimientoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearTipoMovimientoResponse Ejecutar(CrearTipoMovimientoRequest request)
        {

            var tipoMovimiento = _unitOfWork.TipoMovimientoServiceRepository.FindFirstOrDefault(t => t.idMovimiento == request.idMovimiento);
            if (tipoMovimiento == null)
            {
                TipoMovimiento newTipoMovimiento = new TipoMovimiento(request.idMovimiento, request.Nombre);
                IReadOnlyList<string> errors = newTipoMovimiento.CanCrear(newTipoMovimiento);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearTipoMovimientoResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.TipoMovimientoServiceRepository.Add(newTipoMovimiento);
                    _unitOfWork.Commit();
                    return new CrearTipoMovimientoResponse() { Message = $"Tipo Movimiento Exitosamente" };
                }
            }
            else
            {
                return new CrearTipoMovimientoResponse() { Message = $"Tipo Movimiento ya existe" };
            }
        }
    }
}

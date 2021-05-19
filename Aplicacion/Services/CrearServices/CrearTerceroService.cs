using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Aplicacion.Request.CrearTerceroRequest;
namespace Aplicacion.Services.CrearServices
{
    public class CrearTerceroService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearTerceroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearTerceroResponse Ejecutar(CrearTerceroRequest request)
        {

            var terceros = _unitOfWork.TercerosServiceRepository.FindFirstOrDefault(t => t.Identificacion == request.Nit);
            if (terceros == null)
            {
                Terceros newTerceros = new Terceros(request.identificacion, request.tipoId,request.nombre, request.apellido, request.tipoTercero, 
            request.tipoPersona,  request.actividadEconomica,request.responsabilidadFiscal, request.responsableIva 
            ,request.autoRetenedor,request.extranjero, request.celular, request.correo, request.direccion, request.descripcion, 
            request.ciudad, request.telefono, request.estado, request.fechaCumple);
                IReadOnlyList<string> errors = newTerceros.CanCrear(newTerceros);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearTerceroResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.TercerosServiceRepository.Add(newTerceros);
                    _unitOfWork.Commit();
                    return new CrearTerceroResponse() { Message = $"Tercero Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearTerceroResponse() { Message = $"Tercero ya existe" };
            }
        }
    }
}

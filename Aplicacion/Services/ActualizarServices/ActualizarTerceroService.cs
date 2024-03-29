﻿using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarTerceroService
    {
        readonly IUnitOfWork _unitOfWork;
        public ActualizarTerceroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarTerceroResponse Ejecutar(ActualizarTerceroRequest request)
        {
            Terceros terceros = _unitOfWork.TercerosServiceRepository.FindFirstOrDefault(t => t.Identificacion == request.Nit);
            if (terceros == null)
            {
                return new ActualizarTerceroResponse() { Message = $"Tercero no existe" };
            }
            else
            {
                terceros.Apellido = request.Apellido;
                terceros.Celular = request.Celular;
                terceros.Correo = request.Correo;
                terceros.Descripcion = request.Descripcion;
                terceros.Ciudad = request.Ciudad;
                terceros.Telefono = request.Telefono;
                terceros.Direccion = request.Direccion;
                terceros.Identificacion = request.Nit;
                terceros.Nombre = request.Nombre;
                terceros.FechaCumple=request.FechaCumple;
                terceros.TipoTercero = request.TipoTercero;
                _unitOfWork.TercerosServiceRepository.Edit(terceros);
                _unitOfWork.Commit();
                return new ActualizarTerceroResponse() { Message = $"Tercero Actualizado Exitosamente" };
            }
        }
    }
}

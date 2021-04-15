using System;
using System.Collections.Generic;
using System.Text;
using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.ActualizarServices
{
    public class ActualizarUsuarioService
    {
        readonly IUnitOfWork _unitOfWork;

        public ActualizarUsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActualizarUsuarioResponse Ejecutar(ActualizarUsuarioRequest request)
        {
            Usuario usuario = _unitOfWork.UsuarioServiceRepository.FindFirstOrDefault(t => t.EmpleadoId == request.EmpleadoId);
            if (usuario == null)
            {
                return new ActualizarUsuarioResponse() { Message = $"Usuario no existe" };
            }
            else
            {
                usuario.Nombre = request.Nombre;
                usuario.Password = usuario.Encriptar(request.Password);
                usuario.Rol = request.Rol;
                _unitOfWork.UsuarioServiceRepository.Edit(usuario);
                _unitOfWork.Commit();
                return new ActualizarUsuarioResponse() { Message = $"Usuario Actualizado Exitosamente" };
            }
        }
    }
}

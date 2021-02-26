using System;
using System.Collections.Generic;
using System.Text;
using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;

namespace Aplicacion.Services.EliminarServices
{
    public class EliminarUsuarioService
    {
        readonly IUnitOfWork _unitOfWork;
        public EliminarUsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EliminarUsuarioResponse Ejecutar(EliminarUsuarioRequest request){
            Usuario usuario = _unitOfWork.UsuarioServiceRepository.FindFirstOrDefault(t => t.EmpleadoId == request.EmpleadoId);
            if (usuario == null)
                {
                    return new EliminarUsuarioResponse() { Message = $"Usuario no existe" };
                }
                else
                {
                    _unitOfWork.UsuarioServiceRepository.Delete(usuario);
                    _unitOfWork.Commit();
                    return new EliminarUsuarioResponse() { Message = $"Usuario Eliminado Exitosamente" };
                }            
        }
    }
}

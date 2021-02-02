using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Services.Auth
{
    public class LoginService
    {
        readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public LoginResponse Login(LoginRequest request)
        {
            
            var usuario = _unitOfWork.UsuarioServiceRepository.FindFirstOrDefault(t => t.Nombre == request.Usuario);
            if (usuario == null)
            {
                return new LoginResponse() { Message = $"No existe ese usuario" };
            }
            if(usuario.Desencriptar(usuario.Password) == request.Password){
                return new LoginResponse() { 
                    Message = $"Usuario y Contraseña Correctos",
                    EmpleadoId = usuario.EmpleadoId.ToString(),
                    Rol=usuario.Rol, 
                };     
            }
            return new LoginResponse() { Message = $"Contraseña Incorrecta" };
            
        }
    }
}

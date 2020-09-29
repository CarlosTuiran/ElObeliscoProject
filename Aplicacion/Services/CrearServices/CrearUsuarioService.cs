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
    public class CrearUsuarioService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearUsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearUsuarioResponse Ejecutar(CrearUsuarioRequest request)
        {

            var usuario = _unitOfWork.UsuarioServiceRepository.FindFirstOrDefault(t => t.EmpleadoId == request.EmpleadoId);
            if (usuario == null)
            {
                var usuarioRep = _unitOfWork.UsuarioServiceRepository.FindFirstOrDefault(t => t.Nombre == request.Nombre);
                if (usuarioRep != null)
                    return new CrearUsuarioResponse() { Message = $"Nombre de Usuario ya existe" };

                Usuario newUsuario = new Usuario(request.Nombre,  request.Password, request.EmpleadoId, request.Tipo);
                IReadOnlyList<string> errors = newUsuario.CanCrear(newUsuario);
                if (errors.Any())
                {
                    string listaErrors = "Errores: ";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearUsuarioResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.UsuarioServiceRepository.Add(newUsuario);
                    _unitOfWork.Commit();
                    return new CrearUsuarioResponse() { Message = $"Usuario Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearUsuarioResponse() { Message = $"Empleado ya tine un Usuario" };
            }
        }
    }
}

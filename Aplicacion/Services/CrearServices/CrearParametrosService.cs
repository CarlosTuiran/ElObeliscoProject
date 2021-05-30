using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.CrearServices
{
    public class CrearParametrosService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearParametrosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearParametrosResponse Ejecutar(CrearParametrosRequest request)
        {
            var parametro = _unitOfWork.ParametrosServiceRepository.FindFirstOrDefault(t => t.Descripcion == request.Descripcion);
            if (parametro != null)
            {
                return new CrearParametrosResponse() { Message= $"parametro ya existe" };
            }
            Parametros newparametro = new Parametros(request.Agrupacion, request.ValorNumerico, request.ValorTxt, request.Descripcion);
            IReadOnlyList<string> errors = newparametro.CanCrear(newparametro);
            if (errors.Any())
            {
                string listaErrors = "Errores:" + string.Join(",", errors);
                return new CrearParametrosResponse() { Message= listaErrors };
            }
            _unitOfWork.ParametrosServiceRepository.Add(newparametro);
            _unitOfWork.Commit();
            return new CrearParametrosResponse() { Message= "Parametro Creado Exitosamente" };
        }
    }
}

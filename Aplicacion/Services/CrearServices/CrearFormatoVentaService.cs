using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Aplicacion.Services.CrearServices
{
    public class CrearFormatoVentaService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearFormatoVentaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearFormatoVentaResponse Ejecutar(CrearFormatoVentaRequest request)
        {

            var FormatoVenta = _unitOfWork.FormatoVentaServiceRepository.FindFirstOrDefault(t => t.Nombre == request.Nombre);
            if (FormatoVenta == null)
            {
                FormatoVenta newFormatoVenta = new FormatoVenta(request.Nombre, request.Abreviacion, request.Metrica, request.FactorConversion);
                IReadOnlyList<string> errors = newFormatoVenta.CanCrear(newFormatoVenta);
                if (errors.Any())
                {
                    string listaErrors = "Errores:";
                    foreach (var item in errors)
                    {
                        listaErrors += item.ToString();
                    }
                    return new CrearFormatoVentaResponse() { Message = listaErrors };
                }
                else
                {
                    _unitOfWork.FormatoVentaServiceRepository.Add(newFormatoVenta);
                    _unitOfWork.Commit();
                    return new CrearFormatoVentaResponse() { Message = $"Formato Creado Exitosamente" };
                }
            }
            else
            {
                return new CrearFormatoVentaResponse() { Message = $"Formato ya existe" };
            }
        }
    }
}

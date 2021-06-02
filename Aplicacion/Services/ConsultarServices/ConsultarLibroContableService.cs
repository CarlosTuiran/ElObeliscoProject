using Aplicacion.Request.Salidas;
using Domain.Models.Entities;
using Infra.Datos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Services.ConsultarServices
{
    public class ConsultarLibroContableService
    {
        readonly ObeliscoContext _context;
        readonly ConsultarLibroContableResponse _response;
        readonly ListConsultarLibroContableResponse response;

        public ConsultarLibroContableService(ObeliscoContext context)
        {
            _context = context;
            _response = new ConsultarLibroContableResponse();
            response = new ListConsultarLibroContableResponse();
        }

        public ConsultarLibroContableResponse Ejecutar()
        {
            var librosContable = _context.LibroContable.ToList();
            var listaResponses = new List<ListConsultarLibroContableResponse>();
            
            if (librosContable != null)
            {
                foreach (var libroContable in librosContable)
                {
                    response.Codigo = libroContable.Codigo;
                    response.Descripcion = libroContable.Descripcion;
                    response.Debe = string.Format("{0:c}", libroContable.Debe);
                    response.Haber = string.Format("{0:c}", libroContable.Haber);
                    response.OrigenId = libroContable.OrigenId;
                    response.OrigenTipo = libroContable.OrigenTipo;
                    response.Fecha = libroContable.Fecha.ToString("dd-MM-yyyy");
                    listaResponses.Add(response);  
                }
            }
            _response.NombreMov = "Libro Contable";       
            _response.Serial="LC-"+ DateTime.Now.ToString("dd-MM-yyyy");
            _response.Responses = listaResponses;
            return _response;
        }
    }
}

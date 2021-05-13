using Aplicacion.Services.ConsultarServices;
using Domain.Models.Contracts;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearPDF : Controller
    {
        private readonly ObeliscoContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ConsultarFacturaCompra consultarFacturaCompra;
        public CrearPDF(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            consultarFacturaCompra = new ConsultarFacturaCompra(_context, _unitOfWork);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var resultado = _context.Usuario.FirstOrDefault(u => u.Id == 1).Nombre;

            PDFResponse rta = new PDFResponse
            {
                Name = resultado,
                Name2 = "Raul2.0+1.0"
            };
            return new ViewAsPdf("EgresoDiario"){
                Model=rta
               
            };
           
        }
        [HttpGet("/d")]
        public IActionResult EgresoDiario(int facturaId)
        {
            //ViewData.egreso=
            ViewData["NombreMov"]="Egreso Diario";
            ViewBag.NombreMov="Egreso Diario";
            ViewData["Codigo"]="G-2020-12";
            return View();
        }
        [HttpGet("/dd")]
        public IActionResult FacturaCompra(int facturaId)
        {
            return View();
        }
    }
    public class PDFResponse{
        public string Name { get; set; }
        public string Name2 { get; set; }        
        
        
    }
}

using Aplicacion.Services.ConsultarServices;
using Domain.Models.Contracts;
using Domain.Models.Entities;
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
        private readonly ConsultarFacturaCompraService consultarFacturaCompra;
        public CrearPDF(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            consultarFacturaCompra = new ConsultarFacturaCompraService(_context, _unitOfWork);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return new ViewAsPdf("EgresoDiario")
            {
            };
        }
        [HttpGet("/d")]
        public IActionResult EgresoDiario(int facturaId)
        {            
            return View();
        }

        [HttpGet("/FacturaCompraPDF/{facturaId}")]
        public IActionResult FacturaCompra(int facturaId)
        {
            var rta = consultarFacturaCompra.Ejecutar(facturaId);
            return new ViewAsPdf("FacturaCompra")
            {
                Model = rta
            };
        }
    }
}

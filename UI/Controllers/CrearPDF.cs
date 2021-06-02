﻿using Aplicacion.Services.ConsultarServices;
using Domain.Models.Contracts;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Globalization;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearPDF : Controller
    {
        private readonly ObeliscoContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ConsultarFacturaCompraService consultarFacturaCompra;
        private readonly ConsultarEgresoDiarioService consultarEgresoDiario;
        private readonly ConsultarLibroContableService consultarLibroContable;
        private readonly ConsultarLiquidacionService consultarLiquidacion;
        CultureInfo provider = CultureInfo.InvariantCulture;

        public CrearPDF(ObeliscoContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            consultarFacturaCompra = new ConsultarFacturaCompraService(_context, _unitOfWork);
            consultarEgresoDiario = new ConsultarEgresoDiarioService(_context, _unitOfWork);
            consultarLibroContable = new ConsultarLibroContableService(_context);
            consultarLiquidacion = new ConsultarLiquidacionService(_context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return new ViewAsPdf("EgresoDiario")
            {
            };
        }
        [HttpGet("/EgresoDiario/{tercero}")]
        public IActionResult EgresoDiario(string tercero)
        {
            //string format = "ddd MMM dd yyyy";
            //fecha = DateTime.ParseExact(fecha.Substring(0, 15), format, provider).ToString();
            DateTime Fecha = DateTime.Now.AddDays(-1);
            var rta = consultarEgresoDiario.Ejecutar(Fecha, tercero);
            return new ViewAsPdf("EgresoDiario")
            {
                Model = rta
            };
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

        [HttpGet("/Liquidacion/{IdEmpleado}/{idNomina}")]
        public IActionResult Liquidacion(int IdEmpleado, string idNomina)
        {
            var rta = consultarLiquidacion.Ejecutar(IdEmpleado, idNomina);
            return new ViewAsPdf("Liquidacion")
            {
                Model = rta
            };
        }

        [HttpGet("/LibroContablePDF")]
        public IActionResult LibroContable()
        {
            var rta = consultarLibroContable.Ejecutar();
            return new ViewAsPdf("LibroContable")
            {
                Model = rta
            };
        }
    }
}

using Aplicacion.Services.ConsultarServices;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Test.ConsultarTest
{
    [TestFixture]
    public class ConsultarFacturaCompraTest
    {
        ObeliscoContext _context;
        UnitOfWork _unitOfWork;
        ConsultarFacturaCompra _service;
        DbContextOptions options;

        [SetUp]
        public void Setup()
        {
            _context = new ObeliscoContext(options);
            _unitOfWork = new UnitOfWork(_context);
            _service = new ConsultarFacturaCompra(_context,_unitOfWork);
        }
        
        [Test]
        public void ConsultarFacturaCompra()
        {
            var IdFactura = 1;
            var objeto =  _service.Ejecutar(IdFactura);
        }
    }
    
}

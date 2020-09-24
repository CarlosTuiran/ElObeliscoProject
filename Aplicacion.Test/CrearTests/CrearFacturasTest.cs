using Infra.Datos;
using NUnit.Framework;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Services.CrearServices;
using System.Collections.Generic;
using Aplicacion.Request;
using System;

namespace Aplicacion.Test
{
    [TestFixture]

    public class CrearFacturasTest
    {
        ObeliscoTestContext _context;
        UnitOfWork _unitOfWork;
        CrearDFacturaService _Dservice;
        CrearMFacturaService _Mservice;

        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoTestContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoTestContext(optionsInMemory); 
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsMFactura")]
        public void CrearMFacturas(CrearMFacturaRequest mFacturaRequest, string expected)
        {
            _Mservice = new CrearMFacturaService(_unitOfWork);
            var response = _Mservice.Ejecutar(mFacturaRequest);

            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsMFactura()
        {
            yield return new TestCaseData(
                new CrearMFacturaRequest
                {
                    idMfactura = 100000001,
                    EmpleadoId = 106522,
                    TercerosId = 12789,
                    TipoMovimientoId = 7,
                    TipoMovimiento = "Compra",
                    //FechaFactura = DateTime.Now,
                    FechaPago = DateTime.Now,                    
                    SubTotal = 10000,
                    ValorDevolucion = 0,
                    Descuento = 0,
                    IVA = 0.03,
                    Abono = 0,
                    EstadoFactura = "Pendiente"
                },
                "Factura Creada Exitosamente"
                ).SetName("Crear M Factura Correctamente");
        }

        [TestCaseSource("CreationsDFactura")]
        public void CrearDFacturas( List<CrearDFacturaRequest> crearDFacturaRequests, string expected)
        {
            _Dservice = new CrearDFacturaService(_unitOfWork);
            foreach (var dFacturaRequest in crearDFacturaRequests)
            {
                var response = _Dservice.Ejecutar(dFacturaRequest);
                Assert.AreEqual(expected, response.Message);
            }

        }
        private static IEnumerable<TestCaseData> CreationsDFactura()
        {
            yield return new TestCaseData(
                new List<CrearDFacturaRequest> {
                new CrearDFacturaRequest {
                    MfacturaId= 100000001,
                    idDFactura=1000001,
                    Referencia="9900-3333-2222",
                    Cantidad=2,
                    PrecioUnitario=2500,
                    //FechaFactura=DateTime.Now,
                    Bodega ="BD1",
                },
                new CrearDFacturaRequest
                {
                    MfacturaId = 100000001,
                    idDFactura = 1000002,
                    Referencia = "7966-3333-2222",
                    Cantidad = 1,
                    PrecioUnitario = 5000,
                    //FechaFactura = DateTime.Now,
                    Bodega = "BD1",
                }},
                "Detalle de Facturas Creado Exitosamente"
                ).SetName("Crear D Facturas Correctamente");
        }
    }
}

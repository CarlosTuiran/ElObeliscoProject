using Infra.Datos;
using NUnit.Framework;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Services.CrearServices;
using System.Collections.Generic;
using Aplicacion.Request;
using System;

namespace Aplicacion.Test.CrearTests
{
    [TestFixture]
    public class CrearProductoTest
    {
        ObeliscoTestContext _context;
        UnitOfWork _unitOfWork;
        CrearProductoService _Productoservice;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoTestContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoTestContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsProducto")]
        public void CrearProducto(CrearProductoRequest ProductoRequest, string expected)
        {
            _Productoservice = new CrearProductoService(_unitOfWork);
            var response = _Productoservice.Ejecutar(ProductoRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsProducto()
        {
            yield return new TestCaseData(
                new CrearProductoRequest
                {
                    Referencia = "10002",
                    Descripcion = "Cemento",
                    FormatoVenta = "Unidad",
                    IdMarca = 1,
                    IdCategoria = 1,
                    IdProveedor = "106583",
                    Fabrica = "ARGOS",
                    Costo = 25000,
                    PrecioVenta = 30000,
                    CantidadMinima = 10,
                    FechaRegistro = DateTime.Now.Date,
                    CuentaIngreso = 1,
                    CuentaDevolucion = 1,
                    IdImpuestos = new List<int> { }
    },
                "Producto Creado Exitosamente"
                ).SetName("Crear Producto Correctamente");
        }
    }
}

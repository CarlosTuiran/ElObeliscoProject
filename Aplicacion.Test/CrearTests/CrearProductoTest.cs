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
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoTestContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoTestContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsProducto")]
        public void CrearEmpleado(CrearProductoRequest ProductoRequest, string expected)
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
                    Costo = 10000,
                    Descripcion = "Cemento Blanco",
                    Fabrica = "Argos",
                    FormatoVenta = "que va aqui xd",
                    IVA = 0.19,
                    IdMarca=1,
                    IdCategoria=1,
                    IdProveedor="1",
                    PrecioVenta = 12000,
                    Referencia = "tampoco recuerdo que va aqui :'v",
                },
                "Producto Creado Exitosamente"
                ).SetName("Crear Producto Correctamente");
        }
    }
}

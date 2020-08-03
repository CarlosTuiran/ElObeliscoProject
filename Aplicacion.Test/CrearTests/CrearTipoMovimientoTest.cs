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
    public class CrearTipoMovimientoTest
    {
        ObeliscoContext _context;
        UnitOfWork _unitOfWork;
        CrearTipoMovimientoService _TMservice;
        
        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsTipoMovimiento")]
        public void CrearTipoMovimiento(CrearTipoMovimientoRequest TipoMovimientoRequest, string expected)
        {
            _TMservice = new CrearTipoMovimientoService(_unitOfWork);
            var response = _TMservice.Ejecutar(TipoMovimientoRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsTipoMovimiento()
        {
            yield return new TestCaseData(
                new CrearTipoMovimientoRequest
                {
                    idMovimiento = 1000001,
                    Nombre = "Pago Electrónico"
                },
                "Tipo Movimiento creado Exitosamente"
                ).SetName("Crear Tipo Movimiento Correctamente");
        }
    }
}

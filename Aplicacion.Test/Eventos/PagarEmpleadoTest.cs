using Aplicacion.Request;
using Aplicacion.Services.Eventos;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace Aplicacion.Test.Eventos
{
    [TestFixture]
    public class PagarEmpleadoTest
    {
        ObeliscoTestContext _context;
        UnitOfWork _unitOfWork;
        PagarEmpleadoService _PagarEmpleadoservice;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoTestContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoTestContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }
        [TestCaseSource("CreationsPagarEmpleado")]
        public void PagarEmpleado(PagarEmpleadoRequest nominaRequest, string expected)
        {
            _PagarEmpleadoservice = new PagarEmpleadoService(_unitOfWork);
            var response = _PagarEmpleadoservice.Ejecutar(nominaRequest);
            Assert.AreEqual(expected, response.Message);
        }

        private static IEnumerable<TestCaseData> CreationsPagarEmpleado()
        {
            yield return new TestCaseData(
                new PagarEmpleadoRequest
                {
                    IdEmpleado = 2699540
                },
                "Nomina no existe"
                ).SetName("Pagar Empleado Correctamente");
        }
    }
}

using Infra.Datos;
using NUnit.Framework;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Services.Eventos;
using System.Collections.Generic;
using Aplicacion.Request;
using System;

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
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoTestContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoTestContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsPagarEmpleado")]
        public void CrearNomina(PagarEmpleadoRequest nominaRequest, string expected)
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
                    IdEmpleado = 2699540,                    
                    DiasTrabajados = 1300000,
                    HorasExtras = 4,
                    SalarioBase = 1389000,
                    SubTransporte = 143000
                },
                "Empleado Pagado Exitosamente"
                ).SetName("Pagar Empleado Correctamente");
        }
    }
}

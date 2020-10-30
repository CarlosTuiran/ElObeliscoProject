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
    public class CrearNominaTest
    {
        ObeliscoTestContext _context;
        UnitOfWork _unitOfWork;
        CrearNominaService _Nominaservice;

        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoTestContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoTestContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsNomina")]
        public void CrearNomina(CrearNominaRequest nominaRequest, string expected)
        {
            _Nominaservice = new CrearNominaService(_unitOfWork);
            var response = _Nominaservice.Ejecutar(nominaRequest);
            Assert.AreEqual(expected, response.Message);
        }

        private static IEnumerable<TestCaseData> CreationsNomina()
        {
            yield return new TestCaseData(
                new CrearNominaRequest
                {
                    IdEmpleado = 1000001,
                    DiasTrabajados = 1300000,
                    SalarioBase = 1389000,
                    SubTransporte = "Si"
                },
                "Empleado en Nomina Creado Exitosamente"
                ).SetName("Crear Nomina Correctamente");
        }
    }
}

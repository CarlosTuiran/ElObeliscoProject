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
    public class CrearTotalLiquidacionTest
    {
        ObeliscoTestContext _context;
        UnitOfWork _unitOfWork;
        CrearTotalLiquidacionService _CrearTotalLiquidacionservice;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoTestContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoTestContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsCrearTotalLiquidacion")]
        public void CrearNomina(CrearTotalLiquidacionRequest totalLiquidacionRequest, string expected)
        {
            _CrearTotalLiquidacionservice = new CrearTotalLiquidacionService(_unitOfWork);
            var response = _CrearTotalLiquidacionservice.Ejecutar();
            Assert.AreEqual(expected, response.Message);
        }

        private static IEnumerable<TestCaseData> CreationsCrearTotalLiquidacion()
        {
            yield return new TestCaseData(
                new CrearTotalLiquidacionRequest
                {
                    NominaId = "05 - 2021",
                    Mes = 05,
                    Anio = 2021
                },
                "Errores:Campo Valor Total de Nomina vacio"
                ).SetName("Crear Total Liquidacion Correctamente");
        }
    }
}

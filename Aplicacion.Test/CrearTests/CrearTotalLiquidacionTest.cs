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
        ObeliscoContext _context;
        UnitOfWork _unitOfWork;
        CrearTotalLiquidacionService _CrearTotalLiquidacionservice;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ObeliscoContext>().UseSqlServer(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=ObeliescoDB; Integrated Security=True; MultipleActiveResultSets=True").Options;
            _context = new ObeliscoContext(options);
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
                "Total Liquidacion Creado Exitosamente"
                ).SetName("Crear Total Liquidacion Correctamente");
        }
    }
}

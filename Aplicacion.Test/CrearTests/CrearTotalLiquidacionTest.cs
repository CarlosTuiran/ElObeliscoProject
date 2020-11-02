﻿using Infra.Datos;
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
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
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
                    NominaId = "11 - 2020",
                    Mes = 11,
                    Anio = 2020
                },
                "Total Liquidacion creado Exitosamente"
                ).SetName("Crear Total Liquidacion Correctamente");
        }
    }
}
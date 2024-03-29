﻿using Aplicacion.Request;
using Aplicacion.Services.CrearServices;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

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
                    IdEmpleado = 123456,
                    DiasTrabajados = 30,
                    HoraExtraDiurna = 0,
                    HoraExtraNocturna = 0,
                    HoraExtraDiurnaFestivo = 0,
                    HoraExtraNocturnaFestivo = 0,
                    SalarioBase = 1300000,
                    Comisiones = 100000
                },
                "Empleado en Nomina Creado Exitosamente"
                ).SetName("Crear Nomina Correctamente");
        }
    }
}

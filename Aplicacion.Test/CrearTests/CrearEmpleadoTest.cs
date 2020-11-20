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
    public class CrearEmpleadoTest
    {
        ObeliscoTestContext _context;
        UnitOfWork _unitOfWork;
        CrearEmpleadoService _Empleadoservice;

        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoTestContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoTestContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsEmpleado")]
        public void CrearEmpleado(CrearEmpleadoRequest EmpleadoRequest, string expected)
        {
            _Empleadoservice = new CrearEmpleadoService(_unitOfWork);
            var response = _Empleadoservice.Ejecutar(EmpleadoRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsEmpleado()
        {
            yield return new TestCaseData(
                new CrearEmpleadoRequest
                {
                    Apellidos = "Agamez Rapalino",
                    Cargo = "Cajero",
                    Celular = "3024324040",
                    Correo = "raagamez@unicesar.edu.co",
                    Direccion = "Calle 22C #21-61",
                    //Estado = "Activo",
                    IdEmpleado = 1000001,
                    Nombres = "Raul Andres"

                },
                "Empleado Creado Exitosamente"
                ).SetName("Crear Empleado Correctamente");
        }
    }
}

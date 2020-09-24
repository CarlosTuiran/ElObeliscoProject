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
    public class CrearUsuarioTest
    {
        ObeliscoTestContext _context;
        UnitOfWork _unitOfWork;
        CrearUsuarioService _Usuarioservice;

        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoTestContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoTestContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsUsuario")]
        public void CrearEmpleado(CrearUsuarioRequest UsuarioRequest, string expected)
        {
            _Usuarioservice = new CrearUsuarioService(_unitOfWork);
            var response = _Usuarioservice.Ejecutar(UsuarioRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsUsuario()
        {
            yield return new TestCaseData(
                new CrearUsuarioRequest
                {
                    EmpleadoId = 1002301,
                    Nombre = "RaulAgamez",
                    Password="acceso123",
                    Tipo="Admin"

                },
                "Usuario Creado Exitosamente"
                ).SetName("Crear Usuario Correctamente");
        }
    }
}

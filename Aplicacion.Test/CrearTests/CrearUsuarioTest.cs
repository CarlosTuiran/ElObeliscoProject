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

        public void CrearUsuario(CrearUsuarioRequest UsuarioRequest, string expected)
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
                    Rol = "Admin"

                },
                "Usuario Creado Exitosamente"
                ).SetName("Crear Usuario Correctamente");
            yield return new TestCaseData(
                new CrearUsuarioRequest
                {
                    EmpleadoId = 1002301,
                    Nombre = "RaulAgamez",
                    Password="acceso123",
                    Rol = "Admin"

                },
                "Empleado ya tiene un Usuario"
                ).SetName("Crear Usuario con Id Repetido");
            yield return new TestCaseData(
                new CrearUsuarioRequest
                {
                    EmpleadoId = 1003301,
                    Nombre = "RaulAgamez",
                    Password="acceso123",
                    Rol = "Admin"

                },
                "Nombre de Usuario ya existe"
                ).SetName("Crear Usuario con nombre repetidido");
            yield return new TestCaseData(
                new CrearUsuarioRequest
                {
                    
                    Nombre = "RaulAgamez1",
                    Password="acceso123",
                    Rol = "Admin"

                },
                "Errores: Campo IdEmpleado vacio"
                ).SetName("Crear Usuario con campo EmpleadoId vacio");
            yield return new TestCaseData(
                new CrearUsuarioRequest
                {
                    EmpleadoId = 10033012,
                    
                    Password="acceso123",
                    Rol = "Admin"

                },
                "Errores: Campo Nombre vacio"
                ).SetName("Crear Usuario con campo Nombre vacio");
            yield return new TestCaseData(
                new CrearUsuarioRequest
                {
                    EmpleadoId = 1003303,
                    Nombre = "RaulAgamez3",
                    Rol = "Admin"

                },
                "Errores: Campo Password vacio"
                ).SetName("Crear Usuario con Campo Password vacio");
            yield return new TestCaseData(
                new CrearUsuarioRequest
                {
                    EmpleadoId = 10033014,
                    Nombre = "RaulAgamez4",
                    Password="acceso123",
                },
                "Errores: Campo Tipo vacio"
                ).SetName("Crear Usuario con Campo Tipo vacio");
               yield return new TestCaseData(
                new CrearUsuarioRequest
                {
                    EmpleadoId = 10033015,
                    Nombre = "RaulAgamez5",
                    Password="ac",
                    Rol = "Admin"

                },
                "Errores: Campo Password debe tener minimo 6 caracteres"
                ).SetName("Crear Usuario con Campo password de 5 caracteres");
        }
    }
}

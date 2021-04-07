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
    public class CrearTerceroTest
    {
        ObeliscoTestContext _context;
        UnitOfWork _unitOfWork;
        CrearTerceroService _Terceroservice;

        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoTestContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoTestContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("CreationsTercero")]
        public void CrearEmpleado(CrearTerceroRequest TerceroRequest, string expected)
        {
            _Terceroservice = new CrearTerceroService(_unitOfWork);
            var response = _Terceroservice.Ejecutar(TerceroRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsTercero()
        {
            yield return new TestCaseData(
                new CrearTerceroRequest
                {
                    Apellido = "Agamez Rapalino",
                    Celular = "302432165",
                    Correo = "raagamez@unicesar.edu.co",
                    Descripcion = "Hola wenas :v",
                    Direccion = "Calle 22C #21-61",
                    Nit = "32154968413",
                    Nombre = "Raul Andres",
                    TipoTercero = "Proveedor",
                    FechaCumple=DateTime.Now
                },
                "Tercero Creado Exitosamente"
                ).SetName("Crear Tercero Correctamente");
        }
    }
}

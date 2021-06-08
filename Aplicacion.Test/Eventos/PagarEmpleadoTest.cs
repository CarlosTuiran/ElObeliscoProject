using Aplicacion.Request;
using Aplicacion.Services.Eventos;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace Aplicacion.Test.Eventos
{
    [TestFixture]
    public class PagarEmpleadoTest
    {
        ObeliscoContext _context;
        UnitOfWork _unitOfWork;
        PagarEmpleadoService _PagarEmpleadoservice;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ObeliscoContext>().UseSqlServer(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=ObeliescoDB; Integrated Security=True; MultipleActiveResultSets=True").Options;
            _context = new ObeliscoContext(options);
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
                    IdEmpleado = 1
                },
                "Empleado Pagado Exitosamente"
                ).SetName("Pagar Empleado Correctamente");
        }
    }
}

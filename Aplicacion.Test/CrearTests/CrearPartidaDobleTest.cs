using Aplicacion.Request;
using Aplicacion.Services.Eventos;
using Infra.Datos;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Test.CrearTests
{
    [TestFixture]
    public class CrearPartidaDobleTest
    {
        ObeliscoContext _context;
        UnitOfWork _unitOfWork;
        PartidaDobleService _partidaDobleService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ObeliscoContext>().UseSqlServer(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=ObeliescoDB; Integrated Security=True; MultipleActiveResultSets=True").Options;
            _context = new ObeliscoContext(options);
            _unitOfWork = new UnitOfWork(_context);
            _partidaDobleService = new PartidaDobleService(_unitOfWork);
        }
        [TestCaseSource("CreationsLibroContable")]
        public void CrearLibroContable(LibroContableRequest libroContableRequest, string expected)
        {
            var response = _partidaDobleService.RegistroLibroContable(libroContableRequest);
            Assert.AreEqual(expected, response.Message);
        }
        private static IEnumerable<TestCaseData> CreationsLibroContable()
        {
            yield return new TestCaseData(
                new LibroContableRequest
                {
                    Codigo=1105,
                    Descripcion="Compra de lapices",
                    OrigenId=0,
                    OrigenTipo="RegistroLibroContable",
                    TipoMovimientoId=1,
                    Valor=5000
                },
                "Libro Contable Creado Exitosamente"
                ).SetName("Crear Empleado Correctamente");
        }
    }
}

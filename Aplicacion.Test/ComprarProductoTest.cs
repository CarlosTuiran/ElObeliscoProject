using Infra.Datos;
using NUnit.Framework;
using Infra.Datos.Base;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Services.Eventos;

namespace Aplicacion.Test
{
    [TestFixture]
    public class ComprarProductoTest
    {

        ObeliscoContext _context;
        UnitOfWork _unitOfWork;
        ComprarProductoService service;
        [SetUp]
        public void Setup()
        {
            //optionsBuilder.UseMySql(@"Server=localhost; database=cempreddp;uid=acceso;pwd=acceso;");
            var optionsInMemory = new DbContextOptionsBuilder<ObeliscoContext>().UseInMemoryDatabase("Obelisco").Options;
            _context = new ObeliscoContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
        }


        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
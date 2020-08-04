using Domain.Models.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace Domain.Test
{
    public class Tests
    {
        Usuario Usuario;
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource("CifradoData")]
        public void Cifradousuario(string nombre, string password, int idempleado, string expected)
        {
            Usuario = new Usuario(nombre, password, idempleado);
            var passDescript = Usuario.Desencriptar(Usuario.Password);
            Assert.AreEqual(expected, passDescript );
        }
        private static IEnumerable<TestCaseData> CifradoData()
        {
            yield return new TestCaseData(
                
                "CarlosT",
                 "SuperPass123",
                 90903030,
                "SuperPass123"
                ).SetName("Cifrado Funciona Correctamente");
        }
    }
}
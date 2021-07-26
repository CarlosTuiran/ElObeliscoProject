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

        public void Cifradousuario(string nombre, string password, int idempleado, string tipo,string expected)
        {
            Usuario = new Usuario(nombre, password, idempleado, tipo);
            var passDescript = Usuario.Desencriptar(Usuario.Password);
            Assert.AreEqual(expected, passDescript );
        }
        private static IEnumerable<TestCaseData> CifradoData()
        {
            yield return new TestCaseData(
                
                "CarlosT",
                 "SuperPass123",
                 90903030,
                 "Admin",
                "SuperPass123"
                
                ).SetName("Cifrado Funciona Correctamente");
        }
    }
}
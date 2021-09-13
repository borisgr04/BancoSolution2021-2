using NUnit.Framework;
using System;

namespace Banco.Domain.Test
{
    public class DivisionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDivisionDeNumeroExitosa()
        {
            //Test => AAA

            //Arrange - Preparar 
            var service = new OperacionesMatematicasService();
            decimal dividendo = 1000;
            decimal divisor = 10;
            //Act - Acción 
            decimal resultado = service.Dividir(dividendo, divisor);
            //Assert - 
            Assert.AreEqual(100, resultado);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestDivisionPorCeroExitosa()
        {
            //Test => AAA

            //Arrange - Preparar 
            var service = new OperacionesMatematicasService();
            decimal dividendo = 1000;
            decimal divisor = 0;
            //Act - Acción  //            //Assert - 

            Assert.Throws<DivisionPorCeroException>(() => service.Dividir(dividendo, divisor));
        }
    }

   
}
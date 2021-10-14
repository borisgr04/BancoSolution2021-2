using Banco.Infrastructure;
using NUnit.Framework;
using System;

namespace Banco.Application.Test
{
    public class ConsignarCommandHandleTest
    {
        [Test]
        public void PuedeHacerConsignacionInicial()
        {
            var service = new ConsignarCommandHandle(new UnitOfWork());
            
            var command = new ConsignarCommand() 
            {
              NumeroCuenta = "10101",
              ValorConsignacion = 50000, 
              Fecha = new DateTime(2020, 1, 1) 
            };

            var response=service.Handle(command);

            Assert.AreEqual("Su Nuevo Saldo es de $ 50.000,00 pesos m/c", response.Mensaje);
        }
    }
}
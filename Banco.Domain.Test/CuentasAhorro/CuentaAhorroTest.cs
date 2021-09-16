﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Domain.Test.CuentasAhorro
{
    public class CuentaAhorroTest
    {

        /*
        Escenario: Valor de consignación -1
        H1: COMO Cajero del Banco QUIERO realizar consignaciones a una cuenta de ahorro PARA salvaguardar el dinero.
        Criterio de Aceptación:
        1.2 El valor de la consignación no puede ser menor o igual a 0.
        //El ejemplo o escenario
        Dado El cliente tiene una cuenta de ahorro 
        Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0
        Cuando Va a consignar un valor -1
        Entonces El sistema presentará el mensaje. “El valor a consignar es incorrecto”
         */
        [Test]
        public void NoPuedeConsignarValorDeMenosUno()
        {
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ejemplo");
            decimal valorConsignacion = -1;
            string respuesta = cuentaAhorro.Consignar(valorConsignacion: valorConsignacion, fecha: new DateTime(2020,2,1));
            Assert.AreEqual("El valor a consignar es incorrecto", respuesta);
        }

        /*
          Escenario: Consignación Inicial Correcta
            HU: Como Usuario quiero realizar consignaciones a una cuenta de ahorro para salvaguardar el 
            dinero.
            Criterio de Aceptación:
           
            1.1 La consignación inicial debe ser mayor o igual a 50 mil pesos
            1.3 El valor de la consignación se le adicionará al valor del saldo aumentará

            Dado El cliente tiene una cuenta de ahorro 
            Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0
            Cuando Va a consignar el valor inicial de 50 mil pesos 
            Entonces El sistema registrará la consignación
            AND presentará el mensaje. “Su Nuevo Saldo es de $50.000,00 pesos m/c”.
         */
        [Test]
        public void PuedeHacerConsignacionInicialCorrecta()
        {
            var cuentaAhorro = new CuentaAhorro(numero: "10001", nombre: "Cuenta Ejemplo");
            decimal valorConsignacion = 50000;
            string respuesta = cuentaAhorro.Consignar(valorConsignacion: valorConsignacion, fecha: new DateTime(2020, 2, 1));
            Assert.AreEqual(1, cuentaAhorro.Movimientos.Count);//Criterio general
            Assert.AreEqual("Su Nuevo Saldo es de $ 50.000,00 pesos m/c", respuesta);
        }
    }
      
}

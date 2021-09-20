using Banco.Domain.CuentaBancaria;
using System;

namespace Banco.Domain
{
    public class CuentaAhorro : CuentaBancariaBase
    {

        public CuentaAhorro(string numero, string nombre) :
            base(numero, nombre, 50000)
        {

        }



        public override string Retirar(decimal valorRetiro, DateTime fecha)
        {
            var saldoTemporal = Saldo - valorRetiro;
            if (saldoTemporal >= 20000)
            {
                AddMovimientoDisminuyeSaldo(valorRetiro, fecha, "RETIRO");
                return $"Su Nuevo Saldo es de {Saldo:c2} pesos m/c";
            }
            throw new NotImplementedException();
        }
    }



}

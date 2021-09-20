using Banco.Domain.CuentaBancaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain
{
    public class CuentaCorriente : CuentaBancariaBase
    {
        public decimal Sobregiro { get; private set; }

        public CuentaCorriente(string numero, string nombre, decimal sobregiro):base(numero,nombre)
        {
            Sobregiro = -sobregiro;
        }

        public override string Consignar(decimal valorConsignacion, DateTime fecha)
        {
            if (!_movimientos.Any() && valorConsignacion < 100000)
            {
                return "El valor a consignar es incorrecto";
            }

            if (!_movimientos.Any() && valorConsignacion >= 100000)
            {
                _movimientos.Add(new Movimiento(cuentaBancaria: this, fecha: fecha, tipo: "CONSIGNACION", valor: valorConsignacion));
                Saldo += valorConsignacion;
                return $"Su Nuevo Saldo es de {Saldo:c2} pesos m/c";
            }
            throw new NotImplementedException();
        }

        public override string Retirar(decimal valorRetiro, DateTime fecha)
        {
            var cuatroPorMil = valorRetiro * 4 / 1000;
            var nuevoSaldoTemporal = Saldo - valorRetiro - cuatroPorMil;
            if (nuevoSaldoTemporal > Sobregiro)
            {
                _movimientos.Add(new Movimiento(cuentaBancaria: this, fecha: fecha, tipo: "RETIRO", valor: valorRetiro));
                _movimientos.Add(new Movimiento(cuentaBancaria: this, fecha: fecha, tipo: "IMP4XMIL", valor: cuatroPorMil));
                Saldo = nuevoSaldoTemporal;
                return $"Su Nuevo Saldo es de {Saldo:c2} pesos m/c";
            }
            throw new NotImplementedException();
        }
    }


}

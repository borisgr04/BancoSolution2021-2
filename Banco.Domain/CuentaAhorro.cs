using Banco.Domain.CuentaBancaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain
{
    public class CuentaAhorro: CuentaBancariaBase
    {
      
        public CuentaAhorro(string numero, string nombre): base(numero, nombre)
        {
        
        }

        public override string Consignar(decimal valorConsignacion, DateTime fecha)
        {
            if (valorConsignacion < 0)
            {
                return "El valor a consignar es incorrecto";
            }
            if (!_movimientos.Any() && valorConsignacion >= 50000)
            {
                _movimientos.Add(new Movimiento(cuentaBancaria: this, fecha: fecha, tipo: "CONSIGNACION", valor: valorConsignacion));
                Saldo += valorConsignacion;
                return $"Su Nuevo Saldo es de {Saldo:c2} pesos m/c";
            }
            throw new NotImplementedException();
        }

        public override string Retirar(decimal valorRetiro, DateTime fecha)
        {
            var saldoTemporal = Saldo - valorRetiro;
            if (saldoTemporal >= 20000) 
            {
                Saldo = saldoTemporal;
                return $"Su Nuevo Saldo es de {Saldo:c2} pesos m/c";
            }
            throw new NotImplementedException();
        }
    }
    

   
}

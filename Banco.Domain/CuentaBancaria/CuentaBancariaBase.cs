using System;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Domain.CuentaBancaria
{
    public abstract class CuentaBancariaBase
    {

        protected List<Movimiento> _movimientos;
        public string Numero { get; private set; }
        public string Nombre { get; private set; }
        public decimal Saldo { get; protected set; }
        protected decimal ValorMinimoConsignacionInicial; 

        public CuentaBancariaBase(string numero, string nombre, decimal valorMinimoConsignacionInicial)
        {
            Numero = numero;
            Nombre = nombre;
            ValorMinimoConsignacionInicial = valorMinimoConsignacionInicial;
            _movimientos = new List<Movimiento>();
        }

        public IReadOnlyCollection<Movimiento> Movimientos => _movimientos.AsReadOnly();

        public virtual string Consignar(decimal valorConsignacion, DateTime fecha)
        {
            if (!_movimientos.Any() && valorConsignacion < ValorMinimoConsignacionInicial)
            {
                return "El valor a consignar es incorrecto";
            }

            if (!_movimientos.Any() && valorConsignacion >= ValorMinimoConsignacionInicial)
            {
                _movimientos.Add(new Movimiento(cuentaBancaria: this, fecha: fecha, tipo: "CONSIGNACION", valor: valorConsignacion));
                Saldo += valorConsignacion;
                return $"Su Nuevo Saldo es de {Saldo:c2} pesos m/c";
            }
            throw new NotImplementedException();
        }

        public abstract string Retirar(decimal valorRetiro, DateTime fecha);
      
    }
}
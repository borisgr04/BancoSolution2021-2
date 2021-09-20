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

        public CuentaBancariaBase(string numero, string nombre)
        {
            Numero = numero;
            Nombre = nombre;
            _movimientos = new List<Movimiento>();
        }

        public IReadOnlyCollection<Movimiento> Movimientos => _movimientos.AsReadOnly();

        public virtual string Consignar(decimal valorConsignacion, DateTime fecha)
        {
           
            throw new NotImplementedException();
        }

        public abstract string Retirar(decimal valorRetiro, DateTime fecha);
      
    }
}